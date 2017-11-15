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
  public partial class FrameData : TBase
  {
    private int _frameIndex;
    private List<CommandData> _commandList;

    public int FrameIndex
    {
      get
      {
        return _frameIndex;
      }
      set
      {
        __isset.frameIndex = true;
        this._frameIndex = value;
      }
    }

    public List<CommandData> CommandList
    {
      get
      {
        return _commandList;
      }
      set
      {
        __isset.commandList = true;
        this._commandList = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool frameIndex;
      public bool commandList;
    }

    public FrameData() {
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
                FrameIndex = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 20:
              if (field.Type == TType.List) {
                {
                  CommandList = new List<CommandData>();
                  TList _list16 = iprot.ReadListBegin();
                  for( int _i17 = 0; _i17 < _list16.Count; ++_i17)
                  {
                    CommandData _elem18;
                    _elem18 = new CommandData();
                    _elem18.Read(iprot);
                    CommandList.Add(_elem18);
                  }
                  iprot.ReadListEnd();
                }
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
        TStruct struc = new TStruct("FrameData");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (__isset.frameIndex) {
          field.Name = "frameIndex";
          field.Type = TType.I32;
          field.ID = 10;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(FrameIndex);
          oprot.WriteFieldEnd();
        }
        if (CommandList != null && __isset.commandList) {
          field.Name = "commandList";
          field.Type = TType.List;
          field.ID = 20;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteListBegin(new TList(TType.Struct, CommandList.Count));
            foreach (CommandData _iter19 in CommandList)
            {
              _iter19.Write(oprot);
            }
            oprot.WriteListEnd();
          }
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
      StringBuilder __sb = new StringBuilder("FrameData(");
      bool __first = true;
      if (__isset.frameIndex) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("FrameIndex: ");
        __sb.Append(FrameIndex);
      }
      if (CommandList != null && __isset.commandList) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("CommandList: ");
        __sb.Append(CommandList);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
