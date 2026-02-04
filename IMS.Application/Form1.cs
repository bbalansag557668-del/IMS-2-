using IMS.Infustructure.Data;

namespace IMS.Application
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadPrograms();
        }
        private void LoadPrograms(string? searchTerm = null)
        {
            using (var _context = new AppDbContext())
            {
                if (string.IsNullOrEmpty(searchTerm))
                    dataGridView1.DataSource = _context.Programs.ToList();
                else
                    dataGridView1.DataSource = _context.Programs
                        .Where(p => p.Id.ToString().Contains(searchTerm) ||
                                    p.Name.ToLower().Contains(searchTerm) ||
                                    p.Description.ToLower().Contains(searchTerm))
                        .ToList();
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            LoadPrograms(textBoxSearch.Text.ToLower());   
        }
    }
}
