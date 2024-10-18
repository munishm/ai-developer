﻿using Azure;
using Azure.Search.Documents.Indexes;
using BlazorAI.Extensions;
using BlazorAI.Options;
using BlazorAI.Plugins;
using Microsoft.AspNetCore.Components;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.SemanticKernel.Plugins.OpenApi;
#pragma warning disable SKEXP0040 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
#pragma warning disable SKEXP0020 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
#pragma warning disable SKEXP0010 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.

namespace BlazorAI.Components.Pages;

public partial class Chat
{
	private ChatHistory? chatHistory;
	private Kernel? kernel;

	[Inject]
	public required IConfiguration Configuration { get; set; }


	protected async Task InitializeSemanticKernel()
	{
		chatHistory = [];

		// Challenge 02 - Configure Semantic Kernel
		var kernelBuilder = Kernel.CreateBuilder();

		// Challenge 02 - Semantic Kernel Logging configuration
		kernelBuilder.Services.AddLogging(b =>
		{
			b.AddConfiguration(Configuration.GetSection("Logging"));
			b.SetMinimumLevel(LogLevel.Debug);
			b.AddConsole();
		});

		// Challenge 02 - Add OpenAI Chat Completion
		kernelBuilder.AddAzureOpenAIChatCompletion(
			Configuration["AOI_DEPLOYMODEL"]!,
			Configuration["AOI_ENDPOINT"]!,
			Configuration["AOI_API_KEY"]!);

		// Challenge 04 - Services Required By Logic App
		AddRequiredServices(kernelBuilder, Configuration);

		//// Challenge 05 - Register Search Index


		// Challenge 05 - Register Search Index


		// Challenge 07 - Add Azure OpenAI Text To Image


		// Challenge 02 - Finalize Kernel Builder
		kernel = kernelBuilder.Build();

		// Challenge 03, 04, 05, & 07 - Add Plugins
		await AddPlugins();

		// Challenge 02 - Chat Completion Service


		// Challenge 03 - Create OpenAIPromptExecutionSettings


	}


	private async Task AddPlugins()
	{
		// Challenge 03 - Add Time Plugin

		// Challenge 04 - Import Logic App OpenAPI Spec
		
		// Challenge 05 - Add Search Plugin
		
		// Challenge 07 - Text To Image Plugin

	}

	private async Task SendMessage()
	{
		if (!string.IsNullOrWhiteSpace(newMessage) && chatHistory != null)
		{
			// This tells Blazor the UI is going to be updated.
			StateHasChanged();
			loading = true;
			// Copy the user message to a local variable and clear the newMessage field in the UI
			var userMessage = newMessage;
			newMessage = string.Empty;

			// Start Challenge 02 - Sending a message to the chat completion service

			// Your code goes here

			// End Challenge 02 - Sending a message to the chat completion service

			loading = false;
		}
	}
}