using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace GIP.Common
{
    public static class ArrayExtensions
    {
        public static bool Empty(this IEnumerable inList)
        {
            foreach (var _ in inList) {
                return false;
            }
            return true;
        }

        public static IEnumerable<(int, T)> Enumerate<T>(this IList<T> inList, int inStart = 0, int inEnd = -1)
        {
            int end = (inEnd == -1) ? inList.Count : Math.Min(inList.Count, inEnd);
            for (int i = inStart; i < end; ++i) {
                yield return (i, inList[i]);
            }
        }

        public static void ForEach<T>(this IEnumerable<T> inList, Action<T> inAction)
        {
            foreach (T item in inList) {
                inAction(item);
            }
            return;
        }

        public static IEnumerable<R> Convert<T, R>(this IEnumerable<T> inList, Func<T, R> inConverter)
        {
            foreach (T item in inList) {
                yield return inConverter(item);
            }
        }

        public static bool TryGetFirst<T>(this IEnumerable<T> inList, out T outValue, Func<T, bool> inCondition)
        {
            foreach (T item in inList) {
                if (inCondition(item)) {
                    outValue = item;
                    return true;
                }
            }
            outValue = default;
            return false;
        }

        public static bool TryGetAll<T>(this IEnumerable<T> inList, out IEnumerable<T> outResult, Func<T, bool> inCondition)
        {
            outResult = inList.TryGetAll(inCondition);
            return (outResult as List<T>).Count > 0;
        }

        public static IEnumerable<T> TryGetAll<T>(this IEnumerable<T> inList, Func<T, bool> inCondition)
        {
            List<T> result = new List<T>();
            foreach (T item in inList) {
                if (inCondition(item)) {
                    result.Add(item);
                }
            }

            return result;
        }

        public static bool Any<T>(this IEnumerable<T> inList, Predicate<T> inCondition)
        {
            foreach (var item in inList) {
                if (inCondition(item)) {
                    return true;
                }
            }
            return false;
        }

        public static bool All<T>(this IEnumerable<T> inList, Predicate<T> inCondition)
        {
            foreach (var item in inList) {
                if (!inCondition(item)) {
                    return false;
                }
            }
            return true;
        }

        public static void DisposeAndClear<T>(this IList<T> inList) where T : IDisposable
        {
            foreach (var item in inList) {
                item.Dispose();
            }
            inList.Clear();
            return;
        }

        public static IDisposable SubscribeCollectionChanged<T>(this ObservableCollection<T> inList, NotifyCollectionChangedEventHandler inAction)
        {
            return new ObservableCollectionChangedSubscription<T>(inList, inAction);
        }

        private class ObservableCollectionChangedSubscription<T> : IDisposable
        {
            public ObservableCollectionChangedSubscription(ObservableCollection<T> inOwner, NotifyCollectionChangedEventHandler inAction)
            {
                Owner = inOwner;
                Action = inAction;

                Owner.CollectionChanged += Action;
                return;
            }

            public void Dispose()
            {
                Owner.CollectionChanged -= Action;
                return;
            }

            private ObservableCollection<T> Owner
            { get; } = null;
            private NotifyCollectionChangedEventHandler Action
            { get; } = null;
        }
    }
}
