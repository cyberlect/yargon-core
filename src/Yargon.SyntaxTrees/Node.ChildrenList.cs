using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Yargon.SyntaxTrees
{
    partial class Node
    {
        /// <summary>
        /// A list of red node children.
        /// </summary>
        internal sealed class ChildrenList : IChildrenList<INode>
        {
            private readonly INode owner;
            private readonly INode[] children;

            /// <inheritdoc />
            public int Count => this.children.Length;
            
            /// <inheritdoc />
            public INode this[int index]
            {
                get
                {
                    #region Contract
                    if (index < 0 || index >= this.Count)
                        throw new ArgumentOutOfRangeException(nameof(index));
                    #endregion

                    return GetRedChild(index);
                }
            }

            #region Constructors
            /// <summary>
            /// Initializes a new instance of the <see cref="ChildrenList"/> class.
            /// </summary>
            /// <param name="owner">The owner node.</param>
            public ChildrenList(INode owner)
            {
                #region Contract
                if (owner == null)
                    throw new ArgumentNullException(nameof(owner));
                #endregion

                this.owner = owner;
                this.children = new INode[owner.GreenNode.Children.Count];
            }
            #endregion

            /// <inheritdoc />
            public INode TryGet(int index)
            {
                #region Contract
                if (index < 0 || index >= this.Count)
                    throw new ArgumentOutOfRangeException(nameof(index));
                #endregion

                return this.children[index];
            }

            /// <summary>
            /// Creates a new red node or returns a cached one.
            /// </summary>
            /// <param name="index">The zero-based index of the child to get.</param>
            /// <returns>The created or cached red node.</returns>
            private INode GetRedChild(int index)
            {
                #region Contract
                Debug.Assert(index >= 0 && index < this.children.Length);
                #endregion

                var redNode = TryGet(index);
                if (redNode == null)
                {
                    var greenNode = this.owner.GreenNode.Children[index];
                    redNode = this.owner.Factory.Create(greenNode, this.owner, index);
                    this.children[index] = redNode;
                }
                return redNode;
            }

            /// <inheritdoc />
            public IEnumerator<INode> GetEnumerator()
            {
                return ((IEnumerable<INode>)this.children).GetEnumerator();
            }

            /// <inheritdoc />
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
