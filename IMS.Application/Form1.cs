using IMS.Domain.Models;
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
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            LoadPrograms(textBoxSearch.Text.ToLower());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var _context = new AppDbContext())
            {
                try
                {
                    var program = new Programs
                    {
                        Name = textBoxName.Text.Trim(),
                        Description = textBoxDexcription.Text.Trim()
                    };

                    _context.Programs.Add(program);
                    _context.SaveChanges();

                    MessageBox.Show("Program saved succesfully");
                    LoadPrograms();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
