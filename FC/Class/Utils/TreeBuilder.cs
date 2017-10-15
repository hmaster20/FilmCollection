using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FilmCollection
{
    class TreeBuilder
    {
        private RecordCollection RCollection;

        public TreeBuilder(RecordCollection rCollection)
        {
            this.RCollection = rCollection;
        }

        internal TreeNode[] TreeViewCreator()
        {
            TreeNode CollectionNode = new TreeNode();
            if (RCollection.SourceList != null && RCollection.SourceList.Count > 0)
            {
                foreach (Sources src in RCollection.SourceList)
                {
                    if (!string.IsNullOrWhiteSpace(src.Source))
                    {
                        List<string> pathList = PathListBuilder(src);
                        TreeNode Node = TreeNodeBuilder(pathList);
                        CollectionNode.Nodes.Add(Node);
                    }
                }
            }
            return TreeViewBuilder(CollectionNode);
            //treeFolder.AfterSelect += treeFolder_AfterSelect;
        }


        /// <summary>Построени списка путей к каталогам фильмов на основе текущего источника</summary>
        /// <param name="src">Источник файлов (путь)</param>
        /// <returns>Список фильмов</returns>
        private List<string> PathListBuilder(Sources src)
        {
            List<string> pathList = new List<string>();
            pathList.Add(src.Source);
            pathList.AddRange((from cm in RCollection.CombineList
                               let recList = cm.recordList
                               from rec in recList
                               where rec.Visible == true
                               where rec.SourceID == src.Id
                               select rec.FilePath).OrderBy(name => name).Where(n => n.Length > 0).ToList());
            pathList.Select(x => x).Distinct();

            for (int i = 1; i < pathList.Count; i++)
            {
                pathList[i] = src.Source + pathList[i];
            }
            Debug.Print("Выполнен проход создания списка каталогов для ветки: " + src.Source);
            return pathList;
        }


        /// <summary>Создание узлов на основе списка</summary>
        /// <param name="pathList">Список каталогов</param>
        /// <returns>Возращает готовый узел</returns>
        private TreeNode TreeNodeBuilder(List<string> pathList)
        {
            string NodeName = pathList[0];

            TreeNode RootNode = new TreeNode(NodeName);
            TreeNode lastNode = RootNode;
            //lastNode.ToolTipText = "Основная база";

            for (int i = 1; i < pathList.Count; i++)
            {
                if (pathList[i].Contains(NodeName))
                {
                    string[] str = pathList[i].Remove(0, NodeName.Length).TrimStart(Path.DirectorySeparatorChar).Split(Path.DirectorySeparatorChar);

                    if (str.Count() < 1)
                    {
                        // Это корень узла
                        lastNode = RootNode;
                        lastNode.Nodes.Add(str[0] + Path.DirectorySeparatorChar, str[0]);
                    }
                    else
                    {
                        TreeNode[] nodesRoot = RootNode.Nodes.Find((str[0] + Path.DirectorySeparatorChar), true);
                        if (nodesRoot.Length != 0)
                        {
                            lastNode = nodesRoot[0];
                        }
                        else
                        {
                            lastNode = RootNode;
                            lastNode = lastNode.Nodes.Add(str[0] + Path.DirectorySeparatorChar, str[0]);
                        }

                        for (int arr = 1; arr < str.Count(); arr++)
                        {   // Поиск текущего узла, если нет, то создаем, если есть, то запоминаем (выбыираме с нулевым индексом -> nodes[0])
                            TreeNode[] nodes = lastNode.Nodes.Cast<TreeNode>().Where(r => r.Text == str[arr]).ToArray();
                            lastNode = (nodes.Length == 0) ? lastNode.Nodes.Add(str[arr] + Path.DirectorySeparatorChar, str[arr]) : nodes[0];
                        }
                    }
                }
            }
            return RootNode;
        }

        /// <summary>Отображение TreeNode в дереве</summary>
        /// <param name="collectionNode">Набор узлов</param>
        private TreeNode[] TreeViewBuilder(TreeNode collectionNode)
        {
            List<TreeNode> _ListTree = new List<TreeNode>();
            foreach (TreeNode node in collectionNode.Nodes)     // проход по корневым нодам
                _ListTree.Add(node);                            // добавление корневой ноды, содержащей все под-ноды

            return _ListTree.ToArray();
        }
    }
}