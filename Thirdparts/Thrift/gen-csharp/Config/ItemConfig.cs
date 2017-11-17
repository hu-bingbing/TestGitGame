/**
 * Autogenerated by Thrift Compiler (@PACKAGE_VERSION@)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace Config
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class ItemConfig : TBase
  {
    private int _id;
    private string _name;
    private int _type;
    private int _blood;
    private int _mana;
    private int _light;
    private string _dataPrefab;
    private string _assetBundle;
    private string _sourceName;
    private string _dieEffect;

    public int Id
    {
      get
      {
        return _id;
      }
      set
      {
        __isset.id = true;
        this._id = value;
      }
    }

    public string Name
    {
      get
      {
        return _name;
      }
      set
      {
        __isset.name = true;
        this._name = value;
      }
    }

    public int Type
    {
      get
      {
        return _type;
      }
      set
      {
        __isset.type = true;
        this._type = value;
      }
    }

    public int Blood
    {
      get
      {
        return _blood;
      }
      set
      {
        __isset.blood = true;
        this._blood = value;
      }
    }

    public int Mana
    {
      get
      {
        return _mana;
      }
      set
      {
        __isset.mana = true;
        this._mana = value;
      }
    }

    public int Light
    {
      get
      {
        return _light;
      }
      set
      {
        __isset.light = true;
        this._light = value;
      }
    }

    public string DataPrefab
    {
      get
      {
        return _dataPrefab;
      }
      set
      {
        __isset.dataPrefab = true;
        this._dataPrefab = value;
      }
    }

    public string AssetBundle
    {
      get
      {
        return _assetBundle;
      }
      set
      {
        __isset.assetBundle = true;
        this._assetBundle = value;
      }
    }

    public string SourceName
    {
      get
      {
        return _sourceName;
      }
      set
      {
        __isset.sourceName = true;
        this._sourceName = value;
      }
    }

    public string DieEffect
    {
      get
      {
        return _dieEffect;
      }
      set
      {
        __isset.dieEffect = true;
        this._dieEffect = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool id;
      public bool name;
      public bool type;
      public bool blood;
      public bool mana;
      public bool light;
      public bool dataPrefab;
      public bool assetBundle;
      public bool sourceName;
      public bool dieEffect;
    }

    public ItemConfig() {
    }

    public void Read (TProtocol iprot)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 10:
              if (field.Type == TType.I32) {
                Id = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 20:
              if (field.Type == TType.String) {
                Name = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 30:
              if (field.Type == TType.I32) {
                Type = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 32:
              if (field.Type == TType.I32) {
                Blood = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 34:
              if (field.Type == TType.I32) {
                Mana = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 36:
              if (field.Type == TType.I32) {
                Light = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 40:
              if (field.Type == TType.String) {
                DataPrefab = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 50:
              if (field.Type == TType.String) {
                AssetBundle = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 60:
              if (field.Type == TType.String) {
                SourceName = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 70:
              if (field.Type == TType.String) {
                DieEffect = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }
      finally
      {
        iprot.DecrementRecursionDepth();
      }
    }

    public void Write(TProtocol oprot) {
      oprot.IncrementRecursionDepth();
      try
      {
        TStruct struc = new TStruct("ItemConfig");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (__isset.id) {
          field.Name = "id";
          field.Type = TType.I32;
          field.ID = 10;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(Id);
          oprot.WriteFieldEnd();
        }
        if (Name != null && __isset.name) {
          field.Name = "name";
          field.Type = TType.String;
          field.ID = 20;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Name);
          oprot.WriteFieldEnd();
        }
        if (__isset.type) {
          field.Name = "type";
          field.Type = TType.I32;
          field.ID = 30;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(Type);
          oprot.WriteFieldEnd();
        }
        if (__isset.blood) {
          field.Name = "blood";
          field.Type = TType.I32;
          field.ID = 32;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(Blood);
          oprot.WriteFieldEnd();
        }
        if (__isset.mana) {
          field.Name = "mana";
          field.Type = TType.I32;
          field.ID = 34;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(Mana);
          oprot.WriteFieldEnd();
        }
        if (__isset.light) {
          field.Name = "light";
          field.Type = TType.I32;
          field.ID = 36;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(Light);
          oprot.WriteFieldEnd();
        }
        if (DataPrefab != null && __isset.dataPrefab) {
          field.Name = "dataPrefab";
          field.Type = TType.String;
          field.ID = 40;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(DataPrefab);
          oprot.WriteFieldEnd();
        }
        if (AssetBundle != null && __isset.assetBundle) {
          field.Name = "assetBundle";
          field.Type = TType.String;
          field.ID = 50;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(AssetBundle);
          oprot.WriteFieldEnd();
        }
        if (SourceName != null && __isset.sourceName) {
          field.Name = "sourceName";
          field.Type = TType.String;
          field.ID = 60;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(SourceName);
          oprot.WriteFieldEnd();
        }
        if (DieEffect != null && __isset.dieEffect) {
          field.Name = "dieEffect";
          field.Type = TType.String;
          field.ID = 70;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(DieEffect);
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }
      finally
      {
        oprot.DecrementRecursionDepth();
      }
    }

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("ItemConfig(");
      bool __first = true;
      if (__isset.id) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Id: ");
        __sb.Append(Id);
      }
      if (Name != null && __isset.name) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Name: ");
        __sb.Append(Name);
      }
      if (__isset.type) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Type: ");
        __sb.Append(Type);
      }
      if (__isset.blood) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Blood: ");
        __sb.Append(Blood);
      }
      if (__isset.mana) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Mana: ");
        __sb.Append(Mana);
      }
      if (__isset.light) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Light: ");
        __sb.Append(Light);
      }
      if (DataPrefab != null && __isset.dataPrefab) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("DataPrefab: ");
        __sb.Append(DataPrefab);
      }
      if (AssetBundle != null && __isset.assetBundle) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("AssetBundle: ");
        __sb.Append(AssetBundle);
      }
      if (SourceName != null && __isset.sourceName) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("SourceName: ");
        __sb.Append(SourceName);
      }
      if (DieEffect != null && __isset.dieEffect) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("DieEffect: ");
        __sb.Append(DieEffect);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}