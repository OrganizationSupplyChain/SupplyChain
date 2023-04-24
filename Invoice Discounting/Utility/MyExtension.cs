using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Utility
{
   public static class MyExtensions
        {
            public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> items,
                int maxItems)
            {
                return items.Select((item, inx) => new { item, inx })
                    .GroupBy(x => x.inx / maxItems)
                    .Select(g => g.Select(x => x.item));
            }

            public static IEnumerable<IEnumerable<T>> Batchs<T>(this IEnumerable<T> source, int size)
            {
                if (size <= 0)
                    throw new ArgumentOutOfRangeException("size", "Must be greater than zero.");

                using (IEnumerator<T> enumerator = source.GetEnumerator())
                    while (enumerator.MoveNext())
                        yield return TakeIEnumerator(enumerator, size);
            }

            private static IEnumerable<T> TakeIEnumerator<T>(IEnumerator<T> source, int size)
            {
                int i = 0;
                do
                    yield return source.Current;
                while (++i < size && source.MoveNext());
            }

            public static IEnumerable<IEnumerable<T>> Batches<T>(this IEnumerable<T> source, int size)
            {
                List<T> batch = new List<T>();

                foreach (var item in source)
                {
                    batch.Add(item);

                    if (batch.Count >= size)
                    {
                        yield return batch;
                        batch.Clear();
                    }
                }

                if (batch.Count > 0)
                {
                    yield return batch;
                }
            }
        }
    
}
