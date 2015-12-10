using Eto.Drawing;
using Eto.Forms;

namespace Blackboard.Forms
{
	public class BlackboardForm : Form
	{
		public BlackboardForm()
		{
			Title = "Meu quadro-negro";
			ClientSize = new Size(640, 480);

			Content = new Label {
				Text = "Hello!"
			};
		}
	}
}