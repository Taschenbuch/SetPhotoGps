using System;
using System.IO;
using System.Windows.Forms;

namespace SetPhotoGps.Service
{
    public class FolderExplorerService
    {
        public FolderExplorerService(TreeView treeView)
        {
            _treeView1 = treeView;
        }

        public void GetDirectories(DirectoryInfo[] subDirs, TreeNode nodeToAddTo)
        {
            foreach (var subDir in subDirs)
            {
                var aNode = new TreeNode(subDir.Name, 0, 0)
                {
                    Tag = subDir,
                    ImageKey = "folder"
                };
                try
                {
                    DirectoryInfo[] subSubDirs = subDir.GetDirectories();
                    if (subSubDirs.Length != 0)
                    {
                        GetDirectories(subSubDirs, aNode);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                }

                nodeToAddTo.Nodes.Add(aNode);
            }
        }

        public void PopulateTreeView(string selectedFolderPath)
        {
            _treeView1.BeginUpdate();
            _treeView1.Nodes.Clear();
            AddNodes(selectedFolderPath);
            ExpandRootNode();
            _treeView1.EndUpdate();
        }

        private void AddNodes(string selectedFolderPath)
        {
            var info = new DirectoryInfo(selectedFolderPath);
            if (info.Exists)
            {
                var rootNode = new TreeNode(info.Name)
                {
                    Tag = info
                };
                GetDirectories(info.GetDirectories(), rootNode);
                _treeView1.Nodes.Add(rootNode);
            }
        }

        private void ExpandRootNode()
        {
            _treeView1.Nodes[0].Expand();
        }

        private readonly TreeView _treeView1;
    }
}