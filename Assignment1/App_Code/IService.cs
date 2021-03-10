using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

[ServiceContract(Namespace = "/v1/diff")]
public interface IService
{
  /*[OperationContract]
  string GetData(int value);

  [OperationContract]
  CompositeType GetDataUsingDataContract(CompositeType composite);

  // TODO: Add your service operations here
  [OperationContract]
  [WebGet]
  string GetRequest(string get);

  [OperationContract]
  [WebInvoke(Method = "POST")]
  string PostRequest(string post);*/

  Model GetRight(int id);
  Model GetLeft(int id);

  void SetRight(Model rightModel);
  void SetLeft(Model leftModel);

  [WebInvoke(
    Method = "POST",
    UriTemplate = "/{id}/right",
    RequestFormat = WebMessageFormat.Json,
    ResponseFormat = WebMessageFormat.Json)]
  Model Right(int id, Model rightModel);

  [WebInvoke(
    Method = "POST",
    UriTemplate = "/{id}/left",
    RequestFormat = WebMessageFormat.Json,
    ResponseFormat = WebMessageFormat.Json)]
  Model Left(int id, Model leftModel);

  [WebInvoke(
    Method = "GET",
    UriTemplate = "/{id}",
    RequestFormat = WebMessageFormat.Json,
    ResponseFormat = WebMessageFormat.Json)]
  Output Result(int id);
}