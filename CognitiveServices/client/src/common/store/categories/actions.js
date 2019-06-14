import { createAsyncActionType, createAsyncActions } from '../../utilities';

export const GET_CATEGORIES = createAsyncActionType('GET_CATEGORIES');

export const getCategoriesActions = createAsyncActions({ types: GET_CATEGORIES, namespace: 'category' });
