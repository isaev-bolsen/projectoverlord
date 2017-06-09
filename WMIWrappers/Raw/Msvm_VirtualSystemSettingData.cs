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
    
    
    public class Msvm_VirtualSystemSettingData : WMIWrapper {
        
        public Msvm_VirtualSystemSettingData(System.Management.ManagementObject instance) : 
                base(instance) {
        }
        
        public virtual string AdditionalRecoveryInformation {
            get {
                return ((string)(Instance["AdditionalRecoveryInformation"]));
            }
            set {
                Instance["AdditionalRecoveryInformation"] = value;
            }
        }
        
        public virtual System.Nullable<bool> AllowFullSCSICommandSet {
            get {
                return ((System.Nullable<bool>)(Instance["AllowFullSCSICommandSet"]));
            }
            set {
                Instance["AllowFullSCSICommandSet"] = value;
            }
        }
        
        public virtual System.Nullable<bool> AllowReducedFcRedundancy {
            get {
                return ((System.Nullable<bool>)(Instance["AllowReducedFcRedundancy"]));
            }
            set {
                Instance["AllowReducedFcRedundancy"] = value;
            }
        }
        
        public virtual System.Nullable<ushort> AutomaticCriticalErrorAction {
            get {
                return ((System.Nullable<ushort>)(Instance["AutomaticCriticalErrorAction"]));
            }
            set {
                Instance["AutomaticCriticalErrorAction"] = value;
            }
        }
        
        public virtual System.Nullable<System.DateTime> AutomaticCriticalErrorActionTimeout {
            get {
                return ParseDate(Instance["AutomaticCriticalErrorActionTimeout"]);
            }
            set {
                Instance["AutomaticCriticalErrorActionTimeout"] = value;
            }
        }
        
        public virtual System.Nullable<ushort> AutomaticRecoveryAction {
            get {
                return ((System.Nullable<ushort>)(Instance["AutomaticRecoveryAction"]));
            }
            set {
                Instance["AutomaticRecoveryAction"] = value;
            }
        }
        
        public virtual System.Nullable<ushort> AutomaticShutdownAction {
            get {
                return ((System.Nullable<ushort>)(Instance["AutomaticShutdownAction"]));
            }
            set {
                Instance["AutomaticShutdownAction"] = value;
            }
        }
        
        public virtual System.Nullable<ushort> AutomaticStartupAction {
            get {
                return ((System.Nullable<ushort>)(Instance["AutomaticStartupAction"]));
            }
            set {
                Instance["AutomaticStartupAction"] = value;
            }
        }
        
        public virtual System.Nullable<System.DateTime> AutomaticStartupActionDelay {
            get {
                return ParseDate(Instance["AutomaticStartupActionDelay"]);
            }
            set {
                Instance["AutomaticStartupActionDelay"] = value;
            }
        }
        
        public virtual System.Nullable<ushort> AutomaticStartupActionSequenceNumber {
            get {
                return ((System.Nullable<ushort>)(Instance["AutomaticStartupActionSequenceNumber"]));
            }
            set {
                Instance["AutomaticStartupActionSequenceNumber"] = value;
            }
        }
        
        public virtual string BaseBoardSerialNumber {
            get {
                return ((string)(Instance["BaseBoardSerialNumber"]));
            }
            set {
                Instance["BaseBoardSerialNumber"] = value;
            }
        }
        
        public virtual string BIOSGUID {
            get {
                return ((string)(Instance["BIOSGUID"]));
            }
            set {
                Instance["BIOSGUID"] = value;
            }
        }
        
        public virtual System.Nullable<bool> BIOSNumLock {
            get {
                return ((System.Nullable<bool>)(Instance["BIOSNumLock"]));
            }
            set {
                Instance["BIOSNumLock"] = value;
            }
        }
        
        public virtual string BIOSSerialNumber {
            get {
                return ((string)(Instance["BIOSSerialNumber"]));
            }
            set {
                Instance["BIOSSerialNumber"] = value;
            }
        }
        
        public virtual System.Nullable<ushort> BootOrder {
            get {
                return ((System.Nullable<ushort>)(Instance["BootOrder"]));
            }
            set {
                Instance["BootOrder"] = value;
            }
        }
        
        public virtual string BootSourceOrder {
            get {
                return ((string)(Instance["BootSourceOrder"]));
            }
            set {
                Instance["BootSourceOrder"] = value;
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
        
        public virtual string ChassisAssetTag {
            get {
                return ((string)(Instance["ChassisAssetTag"]));
            }
            set {
                Instance["ChassisAssetTag"] = value;
            }
        }
        
        public virtual string ChassisSerialNumber {
            get {
                return ((string)(Instance["ChassisSerialNumber"]));
            }
            set {
                Instance["ChassisSerialNumber"] = value;
            }
        }
        
        public virtual string ConfigurationDataRoot {
            get {
                return ((string)(Instance["ConfigurationDataRoot"]));
            }
            set {
                Instance["ConfigurationDataRoot"] = value;
            }
        }
        
        public virtual string ConfigurationFile {
            get {
                return ((string)(Instance["ConfigurationFile"]));
            }
            set {
                Instance["ConfigurationFile"] = value;
            }
        }
        
        public virtual string ConfigurationID {
            get {
                return ((string)(Instance["ConfigurationID"]));
            }
            set {
                Instance["ConfigurationID"] = value;
            }
        }
        
        public virtual System.Nullable<ushort> ConsoleMode {
            get {
                return ((System.Nullable<ushort>)(Instance["ConsoleMode"]));
            }
            set {
                Instance["ConsoleMode"] = value;
            }
        }
        
        public virtual System.Nullable<System.DateTime> CreationTime {
            get {
                return ParseDate(Instance["CreationTime"]);
            }
            set {
                Instance["CreationTime"] = value;
            }
        }
        
        public virtual System.Nullable<uint> DebugChannelId {
            get {
                return ((System.Nullable<uint>)(Instance["DebugChannelId"]));
            }
            set {
                Instance["DebugChannelId"] = value;
            }
        }
        
        public virtual System.Nullable<uint> DebugPort {
            get {
                return ((System.Nullable<uint>)(Instance["DebugPort"]));
            }
            set {
                Instance["DebugPort"] = value;
            }
        }
        
        public virtual System.Nullable<ushort> DebugPortEnabled {
            get {
                return ((System.Nullable<ushort>)(Instance["DebugPortEnabled"]));
            }
            set {
                Instance["DebugPortEnabled"] = value;
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
        
        public virtual string ElementName {
            get {
                return ((string)(Instance["ElementName"]));
            }
            set {
                Instance["ElementName"] = value;
            }
        }
        
        public virtual System.Nullable<bool> GuestControlledCacheTypes {
            get {
                return ((System.Nullable<bool>)(Instance["GuestControlledCacheTypes"]));
            }
            set {
                Instance["GuestControlledCacheTypes"] = value;
            }
        }
        
        public virtual System.Nullable<ulong> HighMmioGapSize {
            get {
                return ((System.Nullable<ulong>)(Instance["HighMmioGapSize"]));
            }
            set {
                Instance["HighMmioGapSize"] = value;
            }
        }
        
        public virtual System.Nullable<bool> IncrementalBackupEnabled {
            get {
                return ((System.Nullable<bool>)(Instance["IncrementalBackupEnabled"]));
            }
            set {
                Instance["IncrementalBackupEnabled"] = value;
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
        
        public virtual System.Nullable<bool> IsSaved {
            get {
                return ((System.Nullable<bool>)(Instance["IsSaved"]));
            }
            set {
                Instance["IsSaved"] = value;
            }
        }
        
        public virtual System.Nullable<bool> LockOnDisconnect {
            get {
                return ((System.Nullable<bool>)(Instance["LockOnDisconnect"]));
            }
            set {
                Instance["LockOnDisconnect"] = value;
            }
        }
        
        public virtual string LogDataRoot {
            get {
                return ((string)(Instance["LogDataRoot"]));
            }
            set {
                Instance["LogDataRoot"] = value;
            }
        }
        
        public virtual System.Nullable<ulong> LowMmioGapSize {
            get {
                return ((System.Nullable<ulong>)(Instance["LowMmioGapSize"]));
            }
            set {
                Instance["LowMmioGapSize"] = value;
            }
        }
        
        public virtual System.Nullable<ushort> NetworkBootPreferredProtocol {
            get {
                return ((System.Nullable<ushort>)(Instance["NetworkBootPreferredProtocol"]));
            }
            set {
                Instance["NetworkBootPreferredProtocol"] = value;
            }
        }
        
        public virtual string Notes {
            get {
                return ((string)(Instance["Notes"]));
            }
            set {
                Instance["Notes"] = value;
            }
        }
        
        public virtual string Parent {
            get {
                return ((string)(Instance["Parent"]));
            }
            set {
                Instance["Parent"] = value;
            }
        }
        
        public virtual System.Nullable<bool> PauseAfterBootFailure {
            get {
                return ((System.Nullable<bool>)(Instance["PauseAfterBootFailure"]));
            }
            set {
                Instance["PauseAfterBootFailure"] = value;
            }
        }
        
        public virtual string RecoveryFile {
            get {
                return ((string)(Instance["RecoveryFile"]));
            }
            set {
                Instance["RecoveryFile"] = value;
            }
        }
        
        public virtual System.Nullable<bool> SecureBootEnabled {
            get {
                return ((System.Nullable<bool>)(Instance["SecureBootEnabled"]));
            }
            set {
                Instance["SecureBootEnabled"] = value;
            }
        }
        
        public virtual string SecureBootTemplateId {
            get {
                return ((string)(Instance["SecureBootTemplateId"]));
            }
            set {
                Instance["SecureBootTemplateId"] = value;
            }
        }
        
        public virtual string SnapshotDataRoot {
            get {
                return ((string)(Instance["SnapshotDataRoot"]));
            }
            set {
                Instance["SnapshotDataRoot"] = value;
            }
        }
        
        public virtual string SuspendDataRoot {
            get {
                return ((string)(Instance["SuspendDataRoot"]));
            }
            set {
                Instance["SuspendDataRoot"] = value;
            }
        }
        
        public virtual string SwapFileDataRoot {
            get {
                return ((string)(Instance["SwapFileDataRoot"]));
            }
            set {
                Instance["SwapFileDataRoot"] = value;
            }
        }
        
        public virtual System.Nullable<ushort> UserSnapshotType {
            get {
                return ((System.Nullable<ushort>)(Instance["UserSnapshotType"]));
            }
            set {
                Instance["UserSnapshotType"] = value;
            }
        }
        
        public virtual string Version {
            get {
                return ((string)(Instance["Version"]));
            }
            set {
                Instance["Version"] = value;
            }
        }
        
        public virtual System.Nullable<bool> VirtualNumaEnabled {
            get {
                return ((System.Nullable<bool>)(Instance["VirtualNumaEnabled"]));
            }
            set {
                Instance["VirtualNumaEnabled"] = value;
            }
        }
        
        public virtual string VirtualSystemIdentifier {
            get {
                return ((string)(Instance["VirtualSystemIdentifier"]));
            }
            set {
                Instance["VirtualSystemIdentifier"] = value;
            }
        }
        
        public virtual string VirtualSystemSubType {
            get {
                return ((string)(Instance["VirtualSystemSubType"]));
            }
            set {
                Instance["VirtualSystemSubType"] = value;
            }
        }
        
        public virtual string VirtualSystemType {
            get {
                return ((string)(Instance["VirtualSystemType"]));
            }
            set {
                Instance["VirtualSystemType"] = value;
            }
        }
    }
}
