using Syncfusion.Windows.Tools.Controls;
using System;
using System.Windows;
using System.Windows.Controls;

namespace MDIexample
{
    public static class WindowManager
    {
        public static T CreateMDIChild<T>(this DockingManager dm) where T : UserControl, new()
        {
            T mdiChild = null;

            //check if mdi child is already open..select it
            foreach (var form in dm.Children)
            {
                if (form is T)
                {
                    mdiChild = (form as T);
                }
            }

            //if mdi child is not open...open it
            if (mdiChild == null)
            {
                mdiChild = new T();

                DocumentContainer.SetMDIBounds(mdiChild, new Rect(10, 10, 600, 600));
                DockingManager.SetState(mdiChild, DockState.Document);
                dm.Children.Add(mdiChild);
            }

            dm.ActiveWindow = mdiChild;
            return mdiChild;
        }

        internal static void CreateMDIChild<T>()
        {
            throw new NotImplementedException();
        }
    }
}
