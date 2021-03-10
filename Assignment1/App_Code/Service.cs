using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
  private Uri baseAddress = new Uri("http://localhost:8080/");
  private static ServiceHost _serviceHost;

  private Dictionary<int, Model> RightMap = new Dictionary<int, Model>();
  private Dictionary<int, Model> LeftMap = new Dictionary<int, Model>();

  public Model GetRight(int id)
  {
    return RightMap[id];
  }

  public Model GetLeft(int id)
  {
    return LeftMap[id];
  }

  public void SetRight(Model rightModel)
  {
    RightMap[rightModel.Id] = rightModel;
  }

  public void SetLeft(Model leftModel)
  {
    LeftMap[leftModel.Id] = leftModel;
  }

  public Model Right(int id, Model rightModel)
  {
    rightModel.Id = id;
    SetRight(rightModel);
    return rightModel;
  }

  public Model Left(int id, Model leftModel)
  {
    leftModel.Id = id;
    SetLeft(leftModel);
    return leftModel;
  }

  public Output Result(int id)
  {
    Output output = Comparison(id);

    if (output == null)
    {
      return null;
    }
    else
    {
      return output;
    }
  }

  public Output Comparison(int id)
  {
    Output result = null;
    Model leftModel = GetLeft(id);
    Model rightModel = GetRight(id);

    if (leftModel != null && rightModel != null)
    {
      result = new Output(id);
      if (leftModel.Equals(rightModel))
      {
        Console.WriteLine("They are equal!");
      }
      else if (leftModel.Value.Length != rightModel.Value.Length)
      {
        Console.WriteLine("They have different length!");
      }
      else
      {
        Console.WriteLine("They are different!");
        result.ListDifferents = GetDifferences(rightModel, leftModel);
      }
    }

    return result;
  }

  private List<Different> GetDifferences(Model rightModel, Model leftModel)
  {
    List<Different> listDifferences = new List<Different>();
    int index = -1;
    int length = 0;
    for (int i = 0; i < rightModel.Value.Length; i++)
    {
      if (i < rightModel.Value.Length && rightModel.Value[i] != leftModel.Value[i])
      {
        length++;
        if (index < 0)
        {
          index = i;
        }
      }
      else if (index != -1)
      {
        listDifferences.Add(new Different(index, length));
        length = 0;
        index = -1;
      }
    }

    return listDifferences;
  }

  private static void StartService(Uri baseAddress)
  {
    using ( _serviceHost = new ServiceHost(typeof(Service), baseAddress))
    {
      // Enable metadata publishing.
      ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
      smb.HttpGetEnabled = true;
      smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
      _serviceHost.Description.Behaviors.Add(smb);

      // Open the ServiceHost to start listening for messages. Since
      // no endpoints are explicitly configured, the runtime will create
      // one endpoint per base address for each service contract implemented
      // by the service.
      _serviceHost.Open();

      Console.WriteLine("The service is ready at {0}", baseAddress);
      Console.WriteLine("Press <Enter> to stop the service.");
      Console.ReadLine();

      // Close the ServiceHost.
      _serviceHost.Close();
    }
  }
}
