﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.36366
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=4.0.30319.33440.
// 
namespace D3arDiablo.Build.XML {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://inc47.de/BuildSchema")]
    [System.Xml.Serialization.XmlRootAttribute("Classes", Namespace="http://inc47.de/BuildSchema", IsNullable=false)]
    public partial class ClassesContainer {
        
        private BuildContainer crusaderField;
        
        private BuildContainer wizardField;
        
        private BuildContainer monkField;
        
        private BuildContainer demonHunterField;
        
        private BuildContainer barbarianField;
        
        private BuildContainer witchDoctorField;
        
        /// <remarks/>
        public BuildContainer Crusader {
            get {
                return this.crusaderField;
            }
            set {
                this.crusaderField = value;
            }
        }
        
        /// <remarks/>
        public BuildContainer Wizard {
            get {
                return this.wizardField;
            }
            set {
                this.wizardField = value;
            }
        }
        
        /// <remarks/>
        public BuildContainer Monk {
            get {
                return this.monkField;
            }
            set {
                this.monkField = value;
            }
        }
        
        /// <remarks/>
        public BuildContainer DemonHunter {
            get {
                return this.demonHunterField;
            }
            set {
                this.demonHunterField = value;
            }
        }
        
        /// <remarks/>
        public BuildContainer Barbarian {
            get {
                return this.barbarianField;
            }
            set {
                this.barbarianField = value;
            }
        }
        
        /// <remarks/>
        public BuildContainer WitchDoctor {
            get {
                return this.witchDoctorField;
            }
            set {
                this.witchDoctorField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://inc47.de/BuildSchema")]
    public partial class BuildContainer {
        
        private Build[] buildField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Build")]
        public Build[] Build {
            get {
                return this.buildField;
            }
            set {
                this.buildField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://inc47.de/BuildSchema")]
    public partial class Build {
        
        private string nameField;
        
        private Slot shoulderField;
        
        private Slot handsField;
        
        private Slot mainFingerField;
        
        private Slot mainHandField;
        
        private Slot headField;
        
        private Slot torsoField;
        
        private Slot waistField;
        
        private Slot legsField;
        
        private Slot feetField;
        
        private Slot neckField;
        
        private Slot wristField;
        
        private Slot offFingerField;
        
        private Slot offHandField;
        
        private Slot cubeWeaponField;
        
        private Slot cubeArmorField;
        
        private Slot cubeJewelryField;
        
        /// <remarks/>
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        public Slot Shoulder {
            get {
                return this.shoulderField;
            }
            set {
                this.shoulderField = value;
            }
        }
        
        /// <remarks/>
        public Slot Hands {
            get {
                return this.handsField;
            }
            set {
                this.handsField = value;
            }
        }
        
        /// <remarks/>
        public Slot MainFinger {
            get {
                return this.mainFingerField;
            }
            set {
                this.mainFingerField = value;
            }
        }
        
        /// <remarks/>
        public Slot MainHand {
            get {
                return this.mainHandField;
            }
            set {
                this.mainHandField = value;
            }
        }
        
        /// <remarks/>
        public Slot Head {
            get {
                return this.headField;
            }
            set {
                this.headField = value;
            }
        }
        
        /// <remarks/>
        public Slot Torso {
            get {
                return this.torsoField;
            }
            set {
                this.torsoField = value;
            }
        }
        
        /// <remarks/>
        public Slot Waist {
            get {
                return this.waistField;
            }
            set {
                this.waistField = value;
            }
        }
        
        /// <remarks/>
        public Slot Legs {
            get {
                return this.legsField;
            }
            set {
                this.legsField = value;
            }
        }
        
        /// <remarks/>
        public Slot Feet {
            get {
                return this.feetField;
            }
            set {
                this.feetField = value;
            }
        }
        
        /// <remarks/>
        public Slot Neck {
            get {
                return this.neckField;
            }
            set {
                this.neckField = value;
            }
        }
        
        /// <remarks/>
        public Slot Wrist {
            get {
                return this.wristField;
            }
            set {
                this.wristField = value;
            }
        }
        
        /// <remarks/>
        public Slot OffFinger {
            get {
                return this.offFingerField;
            }
            set {
                this.offFingerField = value;
            }
        }
        
        /// <remarks/>
        public Slot OffHand {
            get {
                return this.offHandField;
            }
            set {
                this.offHandField = value;
            }
        }
        
        /// <remarks/>
        public Slot CubeWeapon {
            get {
                return this.cubeWeaponField;
            }
            set {
                this.cubeWeaponField = value;
            }
        }
        
        /// <remarks/>
        public Slot CubeArmor {
            get {
                return this.cubeArmorField;
            }
            set {
                this.cubeArmorField = value;
            }
        }
        
        /// <remarks/>
        public Slot CubeJewelry {
            get {
                return this.cubeJewelryField;
            }
            set {
                this.cubeJewelryField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://inc47.de/BuildSchema")]
    public partial class Slot {
        
        private Item itemField;
        
        /// <remarks/>
        public Item Item {
            get {
                return this.itemField;
            }
            set {
                this.itemField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://inc47.de/BuildSchema")]
    public partial class Item {
        
        private string nameField;
        
        private string uRLField;
        
        private bool ancientField;
        
        private bool foundField;
        
        public Item() {
            this.ancientField = false;
            this.foundField = false;
        }
        
        /// <remarks/>
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        public string URL {
            get {
                return this.uRLField;
            }
            set {
                this.uRLField = value;
            }
        }
        
        /// <remarks/>
        public bool Ancient {
            get {
                return this.ancientField;
            }
            set {
                this.ancientField = value;
            }
        }
        
        /// <remarks/>
        public bool Found {
            get {
                return this.foundField;
            }
            set {
                this.foundField = value;
            }
        }
    }
}
