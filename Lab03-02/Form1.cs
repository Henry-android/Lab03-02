using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lab03_02
{
    public partial class frmSoanThao : Form
    {
        public frmSoanThao()
        {
            InitializeComponent();
        }

        private void frmSoanThao_Load(object sender, EventArgs e)
        {
            toolStripComboBox1.Text = "Tahoma";
            toolStripComboBox2.Text = "14";
            foreach (FontFamily font in new InstalledFontCollection().Families)
            {
                toolStripComboBox1.Items.Add(font.Name);
            }
            List<int> listSize = new List<int> { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (var s in listSize)
            {
                toolStripComboBox2.Items.Add(s);
            }
        }

        private void btnBold_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                FontStyle style = richTextBox1.SelectionFont.Style;

                style ^= FontStyle.Bold; // Toggle Bold
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
            }
        }

        private void btnI_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                FontStyle style = richTextBox1.SelectionFont.Style;

                style ^= FontStyle.Italic; // Toggle Italic
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
            }
        }

        private void btnU_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                FontStyle style = richTextBox1.SelectionFont.Style;

                style ^= FontStyle.Underline; // Toggle Underline
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
            }
        }

        private void địnhDạngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FontDialog fontDialog = new FontDialog())
            {
                fontDialog.ShowColor = true;
                fontDialog.ShowApply = true;

                if (fontDialog.ShowDialog() != DialogResult.Cancel)
                {
                    richTextBox1.SelectionFont = fontDialog.Font;
                    richTextBox1.SelectionColor = fontDialog.Color;
                }
            }
        }
        private void SaveContent()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Rich Text Format|*.rtf|Text Files|*.txt|All Files|*.*";
                saveFileDialog.Title = "Lưu tập tin";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Kiểm tra định dạng lưu
                        if (saveFileDialog.FileName.EndsWith(".rtf"))
                        {
                            richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                        }
                        else
                        {
                            File.WriteAllText(saveFileDialog.FileName, richTextBox1.Text);
                        }

                        MessageBox.Show("Tập tin đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi khi lưu tập tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btnMoi_ButtonClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(richTextBox1.Text)) // Kiểm tra xem có nội dung hay không
            {
                var result = MessageBox.Show("Bạn có muốn lưu nội dung trước khi tạo mới?",
                                             "Xác nhận",
                                             MessageBoxButtons.YesNoCancel,
                                             MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    SaveContent(); // Gọi hàm lưu nội dung
                }
                else if (result == DialogResult.Cancel)
                {
                    return; // Dừng thao tác nếu người dùng chọn Cancel
                }
            }

            // Xóa nội dung
            richTextBox1.Clear();
            MessageBox.Show("Nội dung đã được làm mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mởTậpTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Rich Text Format|*.rtf|Text Files|*.txt|All Files|*.*";
                openFileDialog.Title = "Mở tập tin văn bản";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Kiểm tra loại tập tin và mở
                    if (openFileDialog.FileName.EndsWith(".rtf"))
                    {
                        richTextBox1.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.RichText);
                    }
                    else
                    {
                        richTextBox1.Text = File.ReadAllText(openFileDialog.FileName);
                    }
                }
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            SaveContent();
        }

        private void tạoVănBảnMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(richTextBox1.Text)) // Kiểm tra xem có nội dung hay không
            {
                var result = MessageBox.Show("Bạn có muốn lưu nội dung trước khi tạo mới?",
                                             "Xác nhận",
                                             MessageBoxButtons.YesNoCancel,
                                             MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    SaveContent(); // Gọi hàm lưu nội dung
                }
                else if (result == DialogResult.Cancel)
                {
                    return; // Dừng thao tác nếu người dùng chọn Cancel
                }
            }

            // Xóa nội dung
            richTextBox1.Clear();
            MessageBox.Show("Nội dung đã được làm mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lưuNộiDungVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveContent();

        }
    }
}
