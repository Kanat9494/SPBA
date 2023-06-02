﻿using Microsoft.Extensions.Logging;

namespace SPBA;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		Microsoft.Maui.Handlers.SearchBarHandler.Mapper.AppendToMapping("MyCustomizationSearchBar", (handler, view) =>
		{
#if ANDROID
			Android.Widget.LinearLayout linearLayout = handler.PlatformView.GetChildAt(0) as Android.Widget.LinearLayout;
			linearLayout = linearLayout.GetChildAt(2) as Android.Widget.LinearLayout;
            linearLayout = linearLayout.GetChildAt(1) as Android.Widget.LinearLayout;
            linearLayout.Background = null;
#endif
        });

		return builder.Build();
	}
}
