using HardkorowyKodsu.Application.DTO;
using HardkorowyKodsu.Client.ViewModels;

namespace HardkorowyKodsu.Client
{
    public partial class MainForm : Form
    {
        private readonly DatabaseViewModel _viewModel;

        public MainForm(DatabaseViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            var tablesAndViews = await _viewModel.GetTablesAndViewsAsync();

            treeViewDatabase.Nodes.Clear();

            foreach (var table in tablesAndViews)
            {
                var node = new TreeNode($"{table.Name} - {table.Type}")
                {
                    Tag = table.Name
                };
                treeViewDatabase.Nodes.Add(node);
            }
        }

        private async void treeViewDatabase_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var selectedTable = e.Node.Tag as string;

            if (selectedTable != null)
            {
                var columns = await _viewModel.GetColumnsAsync(selectedTable);

                e.Node.Nodes.Clear();

                foreach (var column in columns)
                {
                    var columnNode = new TreeNode($"{column.Name} - {column.Type}");
                    e.Node.Nodes.Add(columnNode);
                }

                e.Node.Expand();
            }
        }
    }

}
