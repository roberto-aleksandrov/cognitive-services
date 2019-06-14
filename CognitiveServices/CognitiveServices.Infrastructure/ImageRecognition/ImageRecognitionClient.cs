using System;
using System.Net.Http;
using System.Threading.Tasks;
using CognitiveServices.Application.Common.Interfaces.Services;
using CognitiveServices.Application.Common.Models.Contracts.ImageRecognition;
using CognitiveServices.Infrastructure.ImageRecognition;
using RestClient.Builders;
using RestClient.Client.Interfaces;
using RestClient.Models.Enumerations;

namespace CognitiveServices.ImageRecognition.Infrastructure
{
    public class ImageRecognitionClient : IImageRecognitionClient
    {
        private readonly ImageRecognitionOptions _imageRecognitionOptions;
        private readonly IRestClient _restClient;


        public ImageRecognitionClient(ImageRecognitionOptions imageRecognitionOptions)
        {
            _imageRecognitionOptions = imageRecognitionOptions;

            _restClient = new RestClientBuilder()
                .WithSerializer(new Serializer())
                .WithDefaultHeaders(builder =>
                    builder
                        .WithAccept(ContentType.ApplicationJson)
                        .WithContentType(ContentType.OctetStream)
                        .WithHeader("Ocp-Apim-Subscription-Key", imageRecognitionOptions.Key))
                .Build();
        }

        public async Task<ImageRecognitionResponse> SendAsync(ImageRecognitionRequest request)
        {
            var uri = new Uri($"{_imageRecognitionOptions.Url}?details={string.Join(",", request.Details)}&visualFeatures={string.Join(",", request.VisualFeatures)}");

            var response = await _restClient.PostAsync<byte[], ImageRecognitionResponse>(uri, request.Image);

            return response;
        }
    }
}
