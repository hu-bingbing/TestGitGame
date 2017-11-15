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
  public partial class CSSaveDungeonProgress : TBase
  {
    private int _levelId;
    private AutoGen.LevelData _levelData;

    public int LevelId
    {
      get
      {
        return _levelId;
      }
      set
      {
        __isset.levelId = true;
        this._levelId = value;
      }
    }

    public AutoGen.LevelData LevelData
    {
      get
      {
        return _levelData;
      }
      set
      {
        __isset.levelData = true;
        this._levelData = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool levelId;
      public bool levelData;
    }

    public CSSaveDungeonProgress() {
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
                LevelId = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 20:
              if (field.Type == TType.Struct) {
                LevelData = new AutoGen.LevelData();
                LevelData.Read(iprot);
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
        TStruct struc = new TStruct("CSSaveDungeonProgress");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (__isset.levelId) {
          field.Name = "levelId";
          field.Type = TType.I32;
          field.ID = 10;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(LevelId);
          oprot.WriteFieldEnd();
        }
        if (LevelData != null && __isset.levelData) {
          field.Name = "levelData";
          field.Type = TType.Struct;
          field.ID = 20;
          oprot.WriteFieldBegin(field);
          LevelData.Write(oprot);
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
      StringBuilder __sb = new StringBuilder("CSSaveDungeonProgress(");
      bool __first = true;
      if (__isset.levelId) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("LevelId: ");
        __sb.Append(LevelId);
      }
      if (LevelData != null && __isset.levelData) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("LevelData: ");
        __sb.Append(LevelData== null ? "<null>" : LevelData.ToString());
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
