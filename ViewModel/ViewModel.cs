using Model;

namespace ViewModel
{
    class ViewModel
    {
        private static ViewModel _instance = new ViewModel();

        public static ViewModel Instance { get { return _instance; } }

        private Models model;

        private ViewModel()
        {
            model = new Models();
        }
    }
}