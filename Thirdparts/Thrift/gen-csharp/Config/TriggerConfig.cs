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
  public partial class TriggerConfig : TBase
  {
    private int _id;
    private string _name;
    private int _type;
    private string _assetBundle;
    private string _sourceName;
    private int _bonusStrategy;

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

    public int BonusStrategy
    {
      get
      {
        return _bonusStrategy;
      }
      set
      {
        __isset.bonusStrategy = true;
        this._bonusStrategy = value;
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
      public bool assetBundle;
      public bool sourceName;
      public bool bonusStrategy;
    }

    public TriggerConfig() {
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
            case 11:
              if (field.Type == TType.String) {
                Name = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 20:
              if (field.Type == TType.I32) {
                Type = iprot.ReadI32();
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
              if (field.Type == TType.I32) {
                BonusStrategy = iprot.ReadI32();
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
        TStruct struc = new TStruct("TriggerConfig");
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
          field.ID = 11;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Name);
          oprot.WriteFieldEnd();
        }
        if (__isset.type) {
          field.Name = "type";
          field.Type = TType.I32;
          field.ID = 20;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(Type);
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
        if (__isset.bonusStrategy) {
          field.Name = "bonusStrategy";
          field.Type = TType.I32;
          field.ID = 70;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(BonusStrategy);
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
      StringBuilder __sb = new StringBuilder("TriggerConfig(");
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
      if (__isset.bonusStrategy) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("BonusStrategy: ");
        __sb.Append(BonusStrategy);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
