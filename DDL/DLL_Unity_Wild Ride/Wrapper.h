#pragma once
#ifndef _WRAPPER_
#define _WRAPPER_

#include "PluginSettings.h"
#include "Vector2D.h"

#ifdef _cplusplus
extern "C"
{
	#endif

		PLUGIN_API int GetID(void* gameObject);
		PLUGIN_API void SetID(void* gameObject, int id);
		PLUGIN_API Vector2D GetPosition(void* gameObject);
		PLUGIN_API void SetPosition(void* gameObject, float x, float y);

	#ifdef _cplusplus
}
#endif // _cplusplus





#endif // _WRAPPER_