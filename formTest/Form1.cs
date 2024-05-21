

namespace formTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            blobManager manager = new blobManager();
            manager.initializeBM();
            manager.createContainer("testContainer");
            manager.testFileUpload("Hello World");
        }
    }
}
