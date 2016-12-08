using System;
using System.Collections;
using System.Collections.Generic;

namespace Yargon.SyntaxTrees
{
    partial class Node
    {
        /// <summary>
        /// Exposes and casts a slice of a list of nodes.
        /// </summary>
        /// <typeparam name="T">The type to cast to.</typeparam>
        public sealed class SliceList<T> : IChildrenList<T>
            where T : Node
        {
            private readonly IChildrenList<Node> innerList;
            private readonly int offset;
            private readonly int length;

            /// <inheritdoc />
            public int Count => this.length;

            /// <inheritdoc />
            public T this[int index]
            {
                get
                {
                    #region Contract
                    if (index < 0 || index >= this.Count)
                        throw new ArgumentOutOfRangeException(nameof(index));
                    #endregion

                    return (T)this.innerList[this.offset + index];
                }
            }

            #region Constructors
            /// <summary>
            /// Initializes a new instance of the <see cref="SliceList{T}"/> class.
            /// </summary>
            /// <param name="innerList">The inner list.</param>
            /// <param name="offset">The zero-based offset of the slice.</param>
            /// <param name="length">The length of the slice.</param>
            public SliceList(IChildrenList<Node> innerList, int offset, int length)
            {
                #region Contract
                if (innerList == null)
                    throw new ArgumentNullException(nameof(innerList));
                if (offset < 0 || offset > innerList.Count)
                    throw new ArgumentOutOfRangeException(nameof(offset));
                if (length < 0 || offset + length > innerList.Count)
                    throw new ArgumentOutOfRangeException(nameof(length));
                #endregion

                this.innerList = innerList;
                this.offset = offset;
                this.length = length;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="SliceList{T}"/> class.
            /// </summary>
            /// <param name="innerList">The inner list.</param>
            public SliceList(IChildrenList<Node> innerList)
                : this(innerList, 0, innerList?.Count ?? 0)
            {
                // Nothing to do.
            }
            #endregion

            /// <inheritdoc />
            public bool TryGet(int index, out T child)
            {
                #region Contract
                if (index < 0 || index >= this.Count)
                    throw new ArgumentOutOfRangeException(nameof(index));
                #endregion

                Node innerChild;
                if (!this.innerList.TryGet(this.offset + index, out innerChild))
                {
                    child = default(T);
                    return false;
                }
                else
                {
                    child = (T)innerChild;
                    return true;
                }
            }

            /// <inheritdoc />
            public IEnumerator<T> GetEnumerator()
            {
                for (int i = 0; i < this.Count; i++)
                {
                    yield return this[i];
                }
            }

            /// <inheritdoc />
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
