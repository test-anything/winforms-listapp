namespace ListApp;

public class MainForm : Form
{
    private readonly TextBox txtItem;
    private readonly Button btnAdd;
    private readonly Button btnRemove;
    private readonly Button btnClear;
    private readonly ListBox lstItems;
    private readonly Label lblCount;

    public MainForm()
    {
        Text = "إضافة عناصر إلى القائمة";
        RightToLeft = RightToLeft.Yes;
        RightToLeftLayout = true;
        StartPosition = FormStartPosition.CenterScreen;
        ClientSize = new Size(420, 400);
        Font = new Font("Segoe UI", 10F);

        txtItem = new TextBox { Location = new Point(110, 20), Size = new Size(290, 27), PlaceholderText = "اكتب العنصر هنا" };
        btnAdd = new Button { Text = "إضافة", Location = new Point(20, 18), Size = new Size(80, 30) };
        lstItems = new ListBox { Location = new Point(20, 60), Size = new Size(380, 260) };
        btnRemove = new Button { Text = "حذف المحدد", Location = new Point(290, 335), Size = new Size(110, 30) };
        btnClear = new Button { Text = "مسح الكل", Location = new Point(170, 335), Size = new Size(110, 30) };
        lblCount = new Label { Text = "العدد: 0", Location = new Point(20, 340), AutoSize = true };

        btnAdd.Click += (_, _) => AddItem();
        btnRemove.Click += (_, _) =>
        {
            if (lstItems.SelectedIndex >= 0) lstItems.Items.RemoveAt(lstItems.SelectedIndex);
            UpdateCount();
        };
        btnClear.Click += (_, _) => { lstItems.Items.Clear(); UpdateCount(); };
        AcceptButton = btnAdd; // Enter يضيف العنصر

        Controls.AddRange(new Control[] { txtItem, btnAdd, lstItems, btnRemove, btnClear, lblCount });
    }

    private void AddItem()
    {
        var text = txtItem.Text.Trim();
        if (text.Length == 0)
        {
            MessageBox.Show("الرجاء كتابة عنصر أولاً", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        lstItems.Items.Add(text);
        txtItem.Clear();
        txtItem.Focus();
        UpdateCount();
    }

    private void UpdateCount() => lblCount.Text = $"العدد: {lstItems.Items.Count}";
}
