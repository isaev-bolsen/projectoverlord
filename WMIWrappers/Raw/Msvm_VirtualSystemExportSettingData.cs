//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WMIWrappers.Raw {
    
    
    public class Msvm_VirtualSystemExportSettingData : WMIWrapper {
        
        public Msvm_VirtualSystemExportSettingData(System.Management.ManagementObject instance) : 
                base(instance) {
        }
        
        public virtual System.Nullable<sbyte> BackupIntent {
            get {
                return ((System.Nullable<sbyte>)(Instance["BackupIntent"]));
            }
            set {
                Instance["BackupIntent"] = value;
            }
        }
        
        public virtual string Caption {
            get {
                return ((string)(Instance["Caption"]));
            }
            set {
                Instance["Caption"] = value;
            }
        }
        
        public virtual System.Nullable<sbyte> CaptureLiveState {
            get {
                return ((System.Nullable<sbyte>)(Instance["CaptureLiveState"]));
            }
            set {
                Instance["CaptureLiveState"] = value;
            }
        }
        
        public virtual System.Nullable<sbyte> CopySnapshotConfiguration {
            get {
                return ((System.Nullable<sbyte>)(Instance["CopySnapshotConfiguration"]));
            }
            set {
                Instance["CopySnapshotConfiguration"] = value;
            }
        }
        
        public virtual System.Nullable<bool> CopyVmRuntimeInformation {
            get {
                return ((System.Nullable<bool>)(Instance["CopyVmRuntimeInformation"]));
            }
            set {
                Instance["CopyVmRuntimeInformation"] = value;
            }
        }
        
        public virtual System.Nullable<bool> CopyVmStorage {
            get {
                return ((System.Nullable<bool>)(Instance["CopyVmStorage"]));
            }
            set {
                Instance["CopyVmStorage"] = value;
            }
        }
        
        public virtual System.Nullable<bool> CreateVmExportSubdirectory {
            get {
                return ((System.Nullable<bool>)(Instance["CreateVmExportSubdirectory"]));
            }
            set {
                Instance["CreateVmExportSubdirectory"] = value;
            }
        }
        
        public virtual string Description {
            get {
                return ((string)(Instance["Description"]));
            }
            set {
                Instance["Description"] = value;
            }
        }
        
        public virtual string DifferentialBackupBase {
            get {
                return ((string)(Instance["DifferentialBackupBase"]));
            }
            set {
                Instance["DifferentialBackupBase"] = value;
            }
        }
        
        public virtual string ElementName {
            get {
                return ((string)(Instance["ElementName"]));
            }
            set {
                Instance["ElementName"] = value;
            }
        }
        
        public virtual System.Nullable<bool> ExportForLiveMigration {
            get {
                return ((System.Nullable<bool>)(Instance["ExportForLiveMigration"]));
            }
            set {
                Instance["ExportForLiveMigration"] = value;
            }
        }
        
        public virtual string InstanceID {
            get {
                return ((string)(Instance["InstanceID"]));
            }
            set {
                Instance["InstanceID"] = value;
            }
        }
        
        public virtual string SnapshotVirtualSystem {
            get {
                return ((string)(Instance["SnapshotVirtualSystem"]));
            }
            set {
                Instance["SnapshotVirtualSystem"] = value;
            }
        }
    }
}
