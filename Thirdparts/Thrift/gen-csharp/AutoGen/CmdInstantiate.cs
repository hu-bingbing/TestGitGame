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

namespace AutoGen
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class CmdInstantiate : TBase
  {
    private int _uid;
    private int _owner;
    private string _resource;
    private AutoGen.Position _pos;
    private AutoGen.Rotation _rot;

    public int Uid
    {
      get
      {
        return _uid;
      }
      set
      {
        __isset.uid = true;
        this._uid = value;
      }
    }

    public int Owner
    {
      get
      {
        return _owner;
      }
      set
      {
        __isset.owner = true;
        this._owner = value;
      }
    }

    public string Resource
    {
      get
      {
        return _resource;
      }
      set
      {
        __isset.resource = true;
        this._resource = value;
      }
    }

    public AutoGen.Position Pos
    {
      get
      {
        return _pos;
      }
      set
      {
        __isset.pos = true;
        this._pos = value;
      }
    }

    public AutoGen.Rotation Rot
    {
      get
      {
        return _rot;
      }
      set
      {
        __isset.rot = true;
        this._rot = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool uid;
      public bool owner;
      public bool resource;
      public bool pos;
      public bool rot;
    }

    public CmdInstantiate() {
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
                Uid = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 20:
              if (field.Type == TType.I32) {
                Owner = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 30:
              if (field.Type == TType.String) {
                Resource = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 40:
              if (field.Type == TType.Struct) {
                Pos = new AutoGen.Position();
                Pos.Read(iprot);
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 50:
              if (field.Type == TType.Struct) {
                Rot = new AutoGen.Rotation();
                Rot.Read(iprot);
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
        TStruct struc = new TStruct("CmdInstantiate");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (__isset.uid) {
          field.Name = "uid";
          field.Type = TType.I32;
          field.ID = 10;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(Uid);
          oprot.WriteFieldEnd();
        }
        if (__isset.owner) {
          field.Name = "owner";
          field.Type = TType.I32;
          field.ID = 20;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(Owner);
          oprot.WriteFieldEnd();
        }
        if (Resource != null && __isset.resource) {
          field.Name = "resource";
          field.Type = TType.String;
          field.ID = 30;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Resource);
          oprot.WriteFieldEnd();
        }
        if (Pos != null && __isset.pos) {
          field.Name = "pos";
          field.Type = TType.Struct;
          field.ID = 40;
          oprot.WriteFieldBegin(field);
          Pos.Write(oprot);
          oprot.WriteFieldEnd();
        }
        if (Rot != null && __isset.rot) {
          field.Name = "rot";
          field.Type = TType.Struct;
          field.ID = 50;
          oprot.WriteFieldBegin(field);
          Rot.Write(oprot);
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
      StringBuilder __sb = new StringBuilder("CmdInstantiate(");
      bool __first = true;
      if (__isset.uid) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Uid: ");
        __sb.Append(Uid);
      }
      if (__isset.owner) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Owner: ");
        __sb.Append(Owner);
      }
      if (Resource != null && __isset.resource) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Resource: ");
        __sb.Append(Resource);
      }
      if (Pos != null && __isset.pos) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Pos: ");
        __sb.Append(Pos== null ? "<null>" : Pos.ToString());
      }
      if (Rot != null && __isset.rot) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Rot: ");
        __sb.Append(Rot== null ? "<null>" : Rot.ToString());
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
