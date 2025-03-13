using System.ComponentModel;

namespace StoryReader.Controls
{
    /// <summary>
    /// Button with Tooltip
    /// </summary>
    public partial class UcButton: Button
    {    
        public UcButton()
        {
            InitializeComponent();
            SetToolTipIN();
        }

        private ToolTip? tt;

        private string? toolTipText;
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Text displayed on a tooltip for this button."), Category("Behavior")]
        public string? ToolTipText
        {
            get { return toolTipText; }
            set
            {
                toolTipText = value;
                SetToolTipIN();
            }
        }

        /// <summary>Kreiranje ToolTip-a za dugme ako ToolTipText nije prazan.</summary>
        private void SetToolTipIN()
        {
            if (!string.IsNullOrEmpty(ToolTipText))
            {
                tt = new ToolTip();
                tt.SetToolTip(this, ToolTipText);
            }
        }
    }
}
