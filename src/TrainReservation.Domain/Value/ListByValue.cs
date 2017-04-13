// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="ListByValue.cs">
// //     Copyright 2016
// //           Thomas PIERRAIN (@tpierrain)    
// //     Licensed under the Apache License, Version 2.0 (the "License");
// //     you may not use this file except in compliance with the License.
// //     You may obtain a copy of the License at
// //         http://www.apache.org/licenses/LICENSE-2.0
// //     Unless required by applicable law or agreed to in writing, software
// //     distributed under the License is distributed on an "AS IS" BASIS,
// //     WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// //     See the License for the specific language governing permissions and
// //     limitations under the License.b 
// // </copyright>
// // --------------------------------------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;

namespace Value
{
    /// <summary>
    ///     A list with equality based on its content and not on the list's reference 
    ///     (i.e.: 2 different instances containing the same items in the same order will be equals).
    /// </summary>
    /// <remarks>This type is not thread-safe (for hashcode updates).</remarks>
    /// <typeparam name="T">Type of the listed items.</typeparam>
    public class ListByValue<T> : EquatableByValue<ListByValue<T>>, IList<T>
    {
        private readonly IList<T> list;

        public ListByValue() : this(new List<T>())
        {
        }

        public ListByValue(IList<T> list)
        {
            this.list = list;
        }

        public int Count => list.Count;

        public bool IsReadOnly => ((ICollection<T>) list).IsReadOnly;

        public T this[int index]
        {
            get { return list[index]; }
            set
            {
                ResetHashCode();
                list[index] = value;
            }
        }

        public void Add(T item)
        {
            ResetHashCode();
            list.Add(item);
        }

        public void Clear()
        {
            ResetHashCode();
            list.Clear();
        }

        public bool Contains(T item)
        {
            return list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            ResetHashCode();
            list.Insert(index, item);
        }

        public bool Remove(T item)
        {
            ResetHashCode();
            return list.Remove(item);
        }

        public void RemoveAt(int index)
        {
            ResetHashCode();
            list.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) list).GetEnumerator();
        }

        protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality()
        {
            return (IEnumerable<object>) list;
        }
    }
}