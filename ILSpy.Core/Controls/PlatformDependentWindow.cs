using System;
using System.Runtime.InteropServices;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Input.Raw;

namespace ICSharpCode.ILSpy.Controls
{
    public class PlatformDependentWindow : Window
    {
        Action<RawInputEventArgs> originalInputEventHanlder;

        public PlatformDependentWindow()
        {
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            // Close shortcut
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                // Cmd + W
                if (!e.Handled && e.KeyModifiers.HasFlag(KeyModifiers.Control) && e.Key == Key.W)
                {
                    Close();
                    e.Handled = true;
                }

                // Cmd + Q
                if (!e.Handled && e.KeyModifiers.HasFlag(KeyModifiers.Control) && e.Key == Key.Q)
                {
                    Application.Current.Exit();
                    e.Handled = true;
                }
            }
        }
    }
}
