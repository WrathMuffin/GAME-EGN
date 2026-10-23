#pragma once
#ifndef _PLUGIN_SETTINGS_
#define _PLUGIN_SETTINGS_
	
	#ifdef PLUGIN_EXPORTS	
		#define PLUGIN_API __declspec(dllexport)
	
	#elif defined(PLUGIN_IMPORTS)
		#define PLUGIN_API __declspec(dllimport)
	
	#else
		#define PlUGIN_API

	#endif

#endif // _PLUGIN_SETTINGS_