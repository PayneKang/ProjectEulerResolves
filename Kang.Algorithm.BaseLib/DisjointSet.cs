using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kang.Algorithm.BaseLib
{
    /// <summary>
    /// 并查集数据结构
    /// 可以方便的实现克鲁斯卡尔算法
    /// </summary>
    public class DisjointSet
    {
        public int Count { get; private set; }
        private int[] _parent;
        private int[] _rank;
        public DisjointSet(int count)
        {
            this.Count = count;
            this._parent = new int[this.Count];
            this._rank = new int[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                this._parent[i] = i;
                this._rank[i] = 0;
            }
        }
        /// <summary>
        /// 将包含i和j的集合合并
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public void Union(int i, int j)
        {
            int irep = this.Find(i);
            int jrep = this.Find(j);
            if (irep == jrep)
                return;

            int irank = this._rank[irep];
            int jrank = this._rank[jrep];
            if (irank < jrank)
            {
                this._parent[irep] = jrep;
                return;
            }
            if (jrank < irank)
            {
                this._parent[jrep] = irep;
                return;
            }
            this._parent[irep] = jrep;
            this._rank[jrep]++;
        }
        public int Find(int i)
        {
            if (_parent[i] == i)
                return i;

            int result = Find(_parent[i]);
            _parent[i] = result;
            return result;
        }
        public bool IsSpanning()
        {
            return _parent.Distinct().Count() == 1;
        }
    }
}
