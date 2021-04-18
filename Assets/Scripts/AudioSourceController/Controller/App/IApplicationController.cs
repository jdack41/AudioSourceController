using System;

namespace AudioSourceController.Controller.App
{
    public interface IApplicationController
    {
         IDisposable ChangeSelector();
         IDisposable OpenCloseMusicLoadingPanel();
    }
}