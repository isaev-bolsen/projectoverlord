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
    
    
    public class Msvm_VirtualSystemManagementService : WMIWrapper {
        
        public Msvm_VirtualSystemManagementService(System.Management.ManagementObject instance) : 
                base(instance) {
        }
        
        public virtual System.Nullable<ushort> AvailableRequestedStates {
            get {
                return ((System.Nullable<ushort>)(Instance["AvailableRequestedStates"]));
            }
            set {
                Instance["AvailableRequestedStates"] = value;
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
        
        public virtual System.Nullable<ushort> CommunicationStatus {
            get {
                return ((System.Nullable<ushort>)(Instance["CommunicationStatus"]));
            }
            set {
                Instance["CommunicationStatus"] = value;
            }
        }
        
        public virtual string CreationClassName {
            get {
                return ((string)(Instance["CreationClassName"]));
            }
            set {
                Instance["CreationClassName"] = value;
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
        
        public virtual System.Nullable<ushort> DetailedStatus {
            get {
                return ((System.Nullable<ushort>)(Instance["DetailedStatus"]));
            }
            set {
                Instance["DetailedStatus"] = value;
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
        
        public virtual System.Nullable<ushort> EnabledDefault {
            get {
                return ((System.Nullable<ushort>)(Instance["EnabledDefault"]));
            }
            set {
                Instance["EnabledDefault"] = value;
            }
        }
        
        public virtual System.Nullable<ushort> EnabledState {
            get {
                return ((System.Nullable<ushort>)(Instance["EnabledState"]));
            }
            set {
                Instance["EnabledState"] = value;
            }
        }
        
        public virtual System.Nullable<ushort> HealthState {
            get {
                return ((System.Nullable<ushort>)(Instance["HealthState"]));
            }
            set {
                Instance["HealthState"] = value;
            }
        }
        
        public virtual System.Nullable<System.DateTime> InstallDate {
            get {
                return ((System.Nullable<System.DateTime>)(Instance["InstallDate"]));
            }
            set {
                Instance["InstallDate"] = value;
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
        
        public virtual string Name {
            get {
                return ((string)(Instance["Name"]));
            }
            set {
                Instance["Name"] = value;
            }
        }
        
        public virtual System.Nullable<ushort> OperatingStatus {
            get {
                return ((System.Nullable<ushort>)(Instance["OperatingStatus"]));
            }
            set {
                Instance["OperatingStatus"] = value;
            }
        }
        
        public virtual System.Nullable<ushort> OperationalStatus {
            get {
                return ((System.Nullable<ushort>)(Instance["OperationalStatus"]));
            }
            set {
                Instance["OperationalStatus"] = value;
            }
        }
        
        public virtual string OtherEnabledState {
            get {
                return ((string)(Instance["OtherEnabledState"]));
            }
            set {
                Instance["OtherEnabledState"] = value;
            }
        }
        
        public virtual string PrimaryOwnerContact {
            get {
                return ((string)(Instance["PrimaryOwnerContact"]));
            }
            set {
                Instance["PrimaryOwnerContact"] = value;
            }
        }
        
        public virtual string PrimaryOwnerName {
            get {
                return ((string)(Instance["PrimaryOwnerName"]));
            }
            set {
                Instance["PrimaryOwnerName"] = value;
            }
        }
        
        public virtual System.Nullable<ushort> PrimaryStatus {
            get {
                return ((System.Nullable<ushort>)(Instance["PrimaryStatus"]));
            }
            set {
                Instance["PrimaryStatus"] = value;
            }
        }
        
        public virtual System.Nullable<ushort> RequestedState {
            get {
                return ((System.Nullable<ushort>)(Instance["RequestedState"]));
            }
            set {
                Instance["RequestedState"] = value;
            }
        }
        
        public virtual System.Nullable<bool> Started {
            get {
                return ((System.Nullable<bool>)(Instance["Started"]));
            }
            set {
                Instance["Started"] = value;
            }
        }
        
        public virtual string StartMode {
            get {
                return ((string)(Instance["StartMode"]));
            }
            set {
                Instance["StartMode"] = value;
            }
        }
        
        public virtual string Status {
            get {
                return ((string)(Instance["Status"]));
            }
            set {
                Instance["Status"] = value;
            }
        }
        
        public virtual string StatusDescriptions {
            get {
                return ((string)(Instance["StatusDescriptions"]));
            }
            set {
                Instance["StatusDescriptions"] = value;
            }
        }
        
        public virtual string SystemCreationClassName {
            get {
                return ((string)(Instance["SystemCreationClassName"]));
            }
            set {
                Instance["SystemCreationClassName"] = value;
            }
        }
        
        public virtual string SystemName {
            get {
                return ((string)(Instance["SystemName"]));
            }
            set {
                Instance["SystemName"] = value;
            }
        }
        
        public virtual System.Nullable<System.DateTime> TimeOfLastStateChange {
            get {
                return ((System.Nullable<System.DateTime>)(Instance["TimeOfLastStateChange"]));
            }
            set {
                Instance["TimeOfLastStateChange"] = value;
            }
        }
        
        public virtual System.Nullable<ushort> TransitioningToState {
            get {
                return ((System.Nullable<ushort>)(Instance["TransitioningToState"]));
            }
            set {
                Instance["TransitioningToState"] = value;
            }
        }
    }
}
