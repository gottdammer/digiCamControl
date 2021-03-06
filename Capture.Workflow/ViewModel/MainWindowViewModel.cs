﻿using CameraControl.Devices.Classes;
using Capture.Workflow.Core.Classes;
using Capture.Workflow.View;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace Capture.Workflow.ViewModel
{
    public class MainWindowViewModel:ViewModelBase
    {
        public RelayCommand EditCommand { get; set; }
        public AsyncObservableCollection<WorkFlow> WorkFlows { get; set; }  


        public MainWindowViewModel()
        {
            EditCommand = new RelayCommand(Edit);

            ServiceProvider.Instance.DeviceManager.CameraConnected += DeviceManager_CameraConnected;
            ServiceProvider.Instance.DeviceManager.CameraDisconnected += DeviceManager_CameraDisconnected;
            ServiceProvider.Instance.DeviceManager.ConnectToCamera();
            WorkFlows = new AsyncObservableCollection<WorkFlow>();
            WorkFlows.Add(new WorkFlow() {Name = "Workflow 1", Description = "agsgsdg ggsgsfdg sgsdgdsfg sggsfgsd sgsdgsg "});
            WorkFlows.Add(new WorkFlow() { Name = "Workflow 2", Description = "agsgsdg ggsgsfdg sgsdgdsfg sggsfgsd sgsdgsg " });
        }

        private void DeviceManager_CameraDisconnected(CameraControl.Devices.ICameraDevice cameraDevice)
        {
         
        }

        private void DeviceManager_CameraConnected(CameraControl.Devices.ICameraDevice cameraDevice)
        {
         
        }

        private void Edit()
        {
            WorkflowEditorView wnd = new WorkflowEditorView();
            wnd.ShowDialog();
        }
    }
}
