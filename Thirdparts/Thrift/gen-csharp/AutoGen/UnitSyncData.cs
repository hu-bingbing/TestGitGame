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
  public partial class UnitSyncData : TBase
  {
    private int _uid;
    private Position _pos;
    private Rotation _rot;
    private Position _dir;

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

    public Position Pos
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

    public Rotation Rot
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

    public Position Dir
    {
      get
      {
        return _dir;
      }
      set
      {
        __isset.dir = true;
        this._dir = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool uid;
      public bool pos;
      public bool rot;
      public bool dir;
    }

    public UnitSyncData() {
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
              if (field.Type == TType.Struct) {
                Pos = new Position();
                Pos.Read(iprot);
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 30:
              if (field.Type == TType.Struct) {
                Rot = new Rotation();
                Rot.Read(iprot);
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 40:
              if (field.Type == TType.Struct) {
                Dir = new Position();
                Dir.Read(iprot);
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
        TStruct struc = new TStruct("UnitSyncData");
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
        if (Pos != null && __isset.pos) {
          field.Name = "pos";
          field.Type = TType.Struct;
          field.ID = 20;
          oprot.WriteFieldBegin(field);
          Pos.Write(oprot);
          oprot.WriteFieldEnd();
        }
        if (Rot != null && __isset.rot) {
          field.Name = "rot";
          field.Type = TType.Struct;
          field.ID = 30;
          oprot.WriteFieldBegin(field);
          Rot.Write(oprot);
          oprot.WriteFieldEnd();
        }
        if (Dir != null && __isset.dir) {
          field.Name = "dir";
          field.Type = TType.Struct;
          field.ID = 40;
          oprot.WriteFieldBegin(field);
          Dir.Write(oprot);
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
      StringBuilder __sb = new StringBuilder("UnitSyncData(");
      bool __first = true;
      if (__isset.uid) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Uid: ");
        __sb.Append(Uid);
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
      if (Dir != null && __isset.dir) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Dir: ");
        __sb.Append(Dir== null ? "<null>" : Dir.ToString());
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
