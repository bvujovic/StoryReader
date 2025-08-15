
namespace StoryReader.Classes
{
    public enum AppTheme
    {
        Light,
        Dark
    }

    public static class ThemeColors
    {
        public static Color LightBackColor => Color.White;
        public static Color LightForeColor => Color.Black;

        public static Color DarkBackColor => Color.FromArgb(30, 30, 30);
        public static Color DarkForeColor => Color.White;
    }

    public static class FormThemes
    {

        public static void ApplyTheme(Control ctrl, AppTheme theme, HashSet<Control> excludedControls)
        {
            if (!excludedControls.Contains(ctrl))
            {
                var backColor = (theme == AppTheme.Dark) ? ThemeColors.DarkBackColor : ThemeColors.LightBackColor;
                var foreColor = (theme == AppTheme.Dark) ? ThemeColors.DarkForeColor : ThemeColors.LightForeColor;
                ctrl.BackColor = backColor;
                ctrl.ForeColor = foreColor;
                if (ctrl is MenuStrip ms)
                    foreach (ToolStripMenuItem item in ms.Items)
                        ApplyThemeMenuItems(item, theme);
                if (ctrl is DataGridView dgv)
                    ApplyThemeDGV(dgv, theme);
                else
                    foreach (Control child in ctrl.Controls)
                        ApplyTheme(child, theme, excludedControls);
            }
            else
                ctrl.ForeColor = ThemeColors.LightForeColor;
        }

        private static void ApplyThemeMenuItems(ToolStripMenuItem item, AppTheme theme)
        {
            var backColor = (theme == AppTheme.Dark) ? ThemeColors.DarkBackColor : ThemeColors.LightBackColor;
            var foreColor = (theme == AppTheme.Dark) ? Color.OrangeRed : ThemeColors.LightForeColor;
            item.BackColor = backColor;
            item.ForeColor = foreColor;
            foreach (ToolStripMenuItem it in item.DropDownItems)
                ApplyThemeMenuItems(it, theme);
        }

        private static void ApplyThemeDGV(DataGridView dgv, AppTheme theme)
        {
            dgv.BackgroundColor = (theme == AppTheme.Dark) ? ThemeColors.DarkBackColor : ThemeColors.LightBackColor;
            dgv.DefaultCellStyle.BackColor = (theme == AppTheme.Dark) ? Color.FromArgb(45, 45, 45) : Color.White;
            dgv.DefaultCellStyle.ForeColor = (theme == AppTheme.Dark) ? Color.White : Color.Black;
            dgv.DefaultCellStyle.SelectionBackColor = (theme == AppTheme.Dark) ? Color.FromArgb(70, 70, 70) : SystemColors.Highlight;
            dgv.DefaultCellStyle.SelectionForeColor = (theme == AppTheme.Dark) ? Color.White : SystemColors.HighlightText;
        }
    }
}
