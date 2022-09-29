using Model;

namespace ViewModel
{
    class ViewModels
    {
        private static ViewModels _instance = new ViewModels();

        public static ViewModels Instance { get { return _instance; } }

        private Models model;

        private ViewModels()
        {
            model = new Models();
        }
    }
}