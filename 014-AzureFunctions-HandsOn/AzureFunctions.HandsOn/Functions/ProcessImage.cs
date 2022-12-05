using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.IO;

namespace AzureFunctions.HandsOn.Functions
{
    public class ProcessImage
    { 
        /// <summary>
        /// Function that reads the blob data and generate the output processed
        /// </summary>
        /// <param name="source">Source input stream from service</param>
        /// <param name="target">Target input stream to record data</param>
        /// <param name="name">Name of the original blob storage</param>
        /// <param name="log">Logger instance</param>
        [FunctionName("process-image")]
        public void Run(
            [BlobTrigger("images/{name}", Connection = "AzureWebJobsStorage")] Stream source,
            [Blob("images-sm/{name}", FileAccess.Write)] Stream target,
            ILogger log)
        {
            try
            {
                // Execute the process
                using var input = Image.Load<Rgba32>(source, out var format);
                ResizeImage(input, target, (320, 320), format);
            }
            catch (Exception ex)
            {
                log.LogError(ex.Message, ex.StackTrace, ex);
                throw;
            }
        }

        /// <summary>
        /// Function to resize the image
        /// </summary>
        /// <param name="input">Source to be resized</param>
        /// <param name="output">Output stream to be saved</param>
        /// <param name="size">Size parameters (width and height)</param>
        /// <param name="format">Format object</param>
        public static void ResizeImage(Image<Rgba32> input, Stream output, (int width, int height) size, IImageFormat format)
        {
            input.Mutate(x => x.Resize(size.width, size.height));
            input.Save(output, format);
        }
    }
}
