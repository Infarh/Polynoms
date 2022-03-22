using CatAndDogClassificatorModel_TestConsoleApp;


var image_bytes = File.ReadAllBytes(@"TestDog.jpg");

var sample_data = new CatAndDogClassificatorModel.ModelInput
{
    ImageSource = image_bytes,
};

var prediction_result = CatAndDogClassificatorModel.Predict(sample_data);

var labels = prediction_result.PredictedLabel;
var score = prediction_result.Score;
var scores_str = string.Join("; ", score);

Console.WriteLine();
Console.WriteLine($"Predicted Label value: {labels}");
Console.WriteLine($"Predicted Label scores: [{scores_str}]");
