import * as Stranger from './Stranger';
import * as WeatherForecasts from './WeatherForecasts';

import { applyMiddleware, combineReducers, compose, createStore } from 'redux';
import { routerMiddleware, routerReducer } from 'react-router-redux';

import thunk from 'redux-thunk';

export default function configureStore (history, initialState) {
  const reducers = {
    stranger: Stranger.reducer,    
    weatherForecasts: WeatherForecasts.reducer
  };

  const middleware = [
    thunk,
    routerMiddleware(history)
  ];

  // In development, use the browser's Redux dev tools extension if installed
  const enhancers = [];
  const isDevelopment = process.env.NODE_ENV === 'development';
  if (isDevelopment && typeof window !== 'undefined' && window.devToolsExtension) {
    enhancers.push(window.devToolsExtension());
  }

  const rootReducer = combineReducers({
    ...reducers,
    routing: routerReducer
  });

  return createStore(
    rootReducer,
    initialState,
    compose(applyMiddleware(...middleware), ...enhancers)
  );
}
