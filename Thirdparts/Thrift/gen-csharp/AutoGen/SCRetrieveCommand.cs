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
  public partial class SCRetrieveCommand : TBase
  {
    private List<AutoGen.CommandData> _dataList;

    public List<AutoGen.CommandData> DataList
    {
      get
      {
        return _dataList;
      }
      set
      {
        __isset.dataList = true;
        this._dataList = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool dataList;
    }

    public SCRetrieveCommand() {
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
              if (field.Type == TType.List) {
                {
                  DataList = new List<AutoGen.CommandData>();
                  TList _list8 = iprot.ReadListBegin();
                  for( int _i9 = 0; _i9 < _list8.Count; ++_i9)
                  {
                    AutoGen.CommandData _elem10;
                    _elem10 = new AutoGen.CommandData();
                    _elem10.Read(iprot);
                    DataList.Add(_elem10);
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
        TStruct struc = new TStruct("SCRetrieveCommand");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (DataList != null && __isset.dataList) {
          field.Name = "dataList";
          field.Type = TType.List;
          field.ID = 10;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteListBegin(new TList(TType.Struct, DataList.Count));
            foreach (AutoGen.CommandData _iter11 in DataList)
            {
              _iter11.Write(oprot);
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
      StringBuilder __sb = new StringBuilder("SCRetrieveCommand(");
      bool __first = true;
      if (DataList != null && __isset.dataList) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("DataList: ");
        __sb.Append(DataList);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}