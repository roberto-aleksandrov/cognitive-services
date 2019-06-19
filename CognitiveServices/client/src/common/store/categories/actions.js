import { createAsyncActionType, createAsyncActions, createMutations } from '../../utilities';

export const GET_CATEGORIES = createAsyncActionType('GET_CATEGORIES');

export const GET_SUBCATEGORIES = createAsyncActionType('GET_SUBCATEGORIES');

export const getCategoriesActions = createAsyncActions({ types: GET_CATEGORIES, namespace: 'category' });

export const getSubcategoriesActions = createAsyncActions({ types: GET_SUBCATEGORIES, namespace: 'category' });

export const categoriesMutations = createMutations({ names: ['saveCategories', 'saveSubcategories'], namespace: 'category' });
