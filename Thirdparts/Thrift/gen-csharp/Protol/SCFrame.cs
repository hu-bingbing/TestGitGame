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

namespace Protol
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class SCFrame : TBase
  {
    private Protol.FrameData _frameData;

    public Protol.FrameData FrameData
    {
      get
      {
        return _frameData;
      }
      set
      {
        __isset.frameData = true;
        this._frameData = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool frameData;
    }

    public SCFrame() {
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
              if (field.Type == TType.Struct) {
                FrameData = new Protol.FrameData();
                FrameData.Read(iprot);
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
        TStruct struc = new TStruct("SCFrame");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (FrameData != null && __isset.frameData) {
          field.Name = "frameData";
          field.Type = TType.Struct;
          field.ID = 10;
          oprot.WriteFieldBegin(field);
          FrameData.Write(oprot);
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
      StringBuilder __sb = new StringBuilder("SCFrame(");
      bool __first = true;
      if (FrameData != null && __isset.frameData) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("FrameData: ");
        __sb.Append(FrameData== null ? "<null>" : FrameData.ToString());
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
