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
    
    
    public class Msvm_ComputerSystem {
        
        private System.Management.ManagementObject _instance;
        
        public Msvm_ComputerSystem(System.Management.ManagementObject instance) {
            _instance = instance;
        }
        
        protected virtual System.Management.ManagementObject Instance {
            get {
                return _instance;
            }
        }
        
        public virtual System.Nullable<ushort> AvailableRequestedStates {
            get {
                return ((System.Nullable<ushort>)(_instance["AvailableRequestedStates"]));
            }
            set {
                _instance["AvailableRequestedStates"] = value;
            }
        }
        
        public virtual string Caption {
            get {
                return ((string)(_instance["Caption"]));
            }
            set {
                _instance["Caption"] = value;
            }
        }
        
        public virtual System.Nullable<ushort> CommunicationStatus {
            get {
                return ((System.Nullable<ushort>)(_instance["CommunicationStatus"]));
            }
            set {
                _instance["CommunicationStatus"] = value;
            }
        }
        
        public virtual string CreationClassName {
            get {
                return ((string)(_instance["CreationClassName"]));
            }
            set {
                _instance["CreationClassName"] = value;
            }
        }
        
        public virtual System.Nullable<ushort> Dedicated {
            get {
                return ((System.Nullable<ushort>)(_instance["Dedicated"]));
            }
            set {
                _instance["Dedicated"] = value;
            }
        }
        
        public virtual string Description {
            get {
                return ((string)(_instance["Description"]));
            }
            set {
                _instance["Description"] = value;
            }
        }
        
        public virtual System.Nullable<ushort> DetailedStatus {
            get {
                return ((System.Nullable<ushort>)(_instance["DetailedStatus"]));
            }
            set {
                _instance["DetailedStatus"] = value;
            }
        }
        
        public virtual string ElementName {
            get {
                return ((string)(_instance["ElementName"]));
            }
            set {
                _instance["ElementName"] = value;
            }
        }
        
        public virtual System.Nullable<ushort> EnabledDefault {
            get {
                return ((System.Nullable<ushort>)(_instance["EnabledDefault"]));
            }
            set {
                _instance["EnabledDefault"] = value;
            }
        }
        
        public virtual System.Nullable<ushort> EnabledState {
            get {
                return ((System.Nullable<ushort>)(_instance["EnabledState"]));
            }
            set {
                _instance["EnabledState"] = value;
            }
        }
        
        public virtual System.Nullable<ushort> EnhancedSessionModeState {
            get {
                return ((System.Nullable<ushort>)(_instance["EnhancedSessionModeState"]));
            }
            set {
                _instance["EnhancedSessionModeState"] = value;
            }
        }
        
        public virtual System.Nullable<ushort> FailedOverReplicationType {
            get {
                return ((System.Nullable<ushort>)(_instance["FailedOverReplicationType"]));
            }
            set {
                _instance["FailedOverReplicationType"] = value;
            }
        }
        
        public virtual System.Nullable<ushort> HealthState {
            get {
                return ((System.Nullable<ushort>)(_instance["HealthState"]));
            }
            set {
                _instance["HealthState"] = value;
            }
        }
        
        public virtual string IdentifyingDescriptions {
            get {
                return ((string)(_instance["IdentifyingDescriptions"]));
            }
            set {
                _instance["IdentifyingDescriptions"] = value;
            }
        }
        
        public virtual System.Nullable<System.DateTime> InstallDate {
            get {
                return ((System.Nullable<System.DateTime>)(_instance["InstallDate"]));
            }
            set {
                _instance["InstallDate"] = value;
            }
        }
        
        public virtual string InstanceID {
            get {
                return ((string)(_instance["InstanceID"]));
            }
            set {
                _instance["InstanceID"] = value;
            }
        }
        
        public virtual System.Nullable<System.DateTime> LastApplicationConsistentReplicationTime {
            get {
                return ((System.Nullable<System.DateTime>)(_instance["LastApplicationConsistentReplicationTime"]));
            }
            set {
                _instance["LastApplicationConsistentReplicationTime"] = value;
            }
        }
        
        public virtual System.Nullable<System.DateTime> LastReplicationTime {
            get {
                return ((System.Nullable<System.DateTime>)(_instance["LastReplicationTime"]));
            }
            set {
                _instance["LastReplicationTime"] = value;
            }
        }
        
        public virtual System.Nullable<ushort> LastReplicationType {
            get {
                return ((System.Nullable<ushort>)(_instance["LastReplicationType"]));
            }
            set {
                _instance["LastReplicationType"] = value;
            }
        }
        
        public virtual System.Nullable<System.DateTime> LastSuccessfulBackupTime {
            get {
                return ((System.Nullable<System.DateTime>)(_instance["LastSuccessfulBackupTime"]));
            }
            set {
                _instance["LastSuccessfulBackupTime"] = value;
            }
        }
        
        public virtual string Name {
            get {
                return ((string)(_instance["Name"]));
            }
            set {
                _instance["Name"] = value;
            }
        }
        
        public virtual string NameFormat {
            get {
                return ((string)(_instance["NameFormat"]));
            }
            set {
                _instance["NameFormat"] = value;
            }
        }
        
        public virtual System.Nullable<ushort> NumberOfNumaNodes {
            get {
                return ((System.Nullable<ushort>)(_instance["NumberOfNumaNodes"]));
            }
            set {
                _instance["NumberOfNumaNodes"] = value;
            }
        }
        
        public virtual System.Nullable<ulong> OnTimeInMilliseconds {
            get {
                return ((System.Nullable<ulong>)(_instance["OnTimeInMilliseconds"]));
            }
            set {
                _instance["OnTimeInMilliseconds"] = value;
            }
        }
        
        public virtual System.Nullable<ushort> OperatingStatus {
            get {
                return ((System.Nullable<ushort>)(_instance["OperatingStatus"]));
            }
            set {
                _instance["OperatingStatus"] = value;
            }
        }
        
        public virtual System.Nullable<ushort> OperationalStatus {
            get {
                return ((System.Nullable<ushort>)(_instance["OperationalStatus"]));
            }
            set {
                _instance["OperationalStatus"] = value;
            }
        }
        
        public virtual string OtherDedicatedDescriptions {
            get {
                return ((string)(_instance["OtherDedicatedDescriptions"]));
            }
            set {
                _instance["OtherDedicatedDescriptions"] = value;
            }
        }
        
        public virtual string OtherEnabledState {
            get {
                return ((string)(_instance["OtherEnabledState"]));
            }
            set {
                _instance["OtherEnabledState"] = value;
            }
        }
        
        public virtual string OtherIdentifyingInfo {
            get {
                return ((string)(_instance["OtherIdentifyingInfo"]));
            }
            set {
                _instance["OtherIdentifyingInfo"] = value;
            }
        }
        
        public virtual System.Nullable<ushort> PowerManagementCapabilities {
            get {
                return ((System.Nullable<ushort>)(_instance["PowerManagementCapabilities"]));
            }
            set {
                _instance["PowerManagementCapabilities"] = value;
            }
        }
        
        public virtual string PrimaryOwnerContact {
            get {
                return ((string)(_instance["PrimaryOwnerContact"]));
            }
            set {
                _instance["PrimaryOwnerContact"] = value;
            }
        }
        
        public virtual string PrimaryOwnerName {
            get {
                return ((string)(_instance["PrimaryOwnerName"]));
            }
            set {
                _instance["PrimaryOwnerName"] = value;
            }
        }
        
        public virtual System.Nullable<ushort> PrimaryStatus {
            get {
                return ((System.Nullable<ushort>)(_instance["PrimaryStatus"]));
            }
            set {
                _instance["PrimaryStatus"] = value;
            }
        }
        
        public virtual System.Nullable<uint> ProcessID {
            get {
                return ((System.Nullable<uint>)(_instance["ProcessID"]));
            }
            set {
                _instance["ProcessID"] = value;
            }
        }
        
        public virtual System.Nullable<ushort> ReplicationHealth {
            get {
                return ((System.Nullable<ushort>)(_instance["ReplicationHealth"]));
            }
            set {
                _instance["ReplicationHealth"] = value;
            }
        }
        
        public virtual System.Nullable<ushort> ReplicationMode {
            get {
                return ((System.Nullable<ushort>)(_instance["ReplicationMode"]));
            }
            set {
                _instance["ReplicationMode"] = value;
            }
        }
        
        public virtual System.Nullable<ushort> ReplicationState {
            get {
                return ((System.Nullable<ushort>)(_instance["ReplicationState"]));
            }
            set {
                _instance["ReplicationState"] = value;
            }
        }
        
        public virtual System.Nullable<ushort> RequestedState {
            get {
                return ((System.Nullable<ushort>)(_instance["RequestedState"]));
            }
            set {
                _instance["RequestedState"] = value;
            }
        }
        
        public virtual System.Nullable<ushort> ResetCapability {
            get {
                return ((System.Nullable<ushort>)(_instance["ResetCapability"]));
            }
            set {
                _instance["ResetCapability"] = value;
            }
        }
        
        public virtual string Roles {
            get {
                return ((string)(_instance["Roles"]));
            }
            set {
                _instance["Roles"] = value;
            }
        }
        
        public virtual string Status {
            get {
                return ((string)(_instance["Status"]));
            }
            set {
                _instance["Status"] = value;
            }
        }
        
        public virtual string StatusDescriptions {
            get {
                return ((string)(_instance["StatusDescriptions"]));
            }
            set {
                _instance["StatusDescriptions"] = value;
            }
        }
        
        public virtual System.Nullable<System.DateTime> TimeOfLastConfigurationChange {
            get {
                return ((System.Nullable<System.DateTime>)(_instance["TimeOfLastConfigurationChange"]));
            }
            set {
                _instance["TimeOfLastConfigurationChange"] = value;
            }
        }
        
        public virtual System.Nullable<System.DateTime> TimeOfLastStateChange {
            get {
                return ((System.Nullable<System.DateTime>)(_instance["TimeOfLastStateChange"]));
            }
            set {
                _instance["TimeOfLastStateChange"] = value;
            }
        }
        
        public virtual System.Nullable<ushort> TransitioningToState {
            get {
                return ((System.Nullable<ushort>)(_instance["TransitioningToState"]));
            }
            set {
                _instance["TransitioningToState"] = value;
            }
        }
    }
}
