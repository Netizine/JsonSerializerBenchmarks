using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Validators;
using JsonSerializerBenchmarks;



BenchmarkRunner.Run<JsonSerializationBenchmarks>(DefaultConfig.Instance
    .AddJob(Job.Default.WithRuntime(CoreRuntime.Core60))
    .AddValidator(ExecutionValidator.FailOnError));

BenchmarkRunner.Run<JsonDeserializationBenchmarks>(DefaultConfig.Instance
    .AddJob(Job.Default.WithRuntime(CoreRuntime.Core60))
    .AddValidator(ExecutionValidator.FailOnError));

Console.ReadLine();