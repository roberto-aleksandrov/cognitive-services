import { createAsyncActionType, createAsyncActions, createMutations } from '../../utilities';

export const GET_PICTURES = createAsyncActionType('GET_PICTURES');

export const GET_PICTURE = createAsyncActionType('GET_PICTURE');

export const DELETE_PICTURE = createAsyncActionType('DELETE_PICTURE');

export const deletePictureActions = createAsyncActions({ types: DELETE_PICTURE, namespace: 'picture' });

export const getPicturesActions = createAsyncActions({ types: GET_PICTURES, namespace: 'picture' });

export const getPictureActions = createAsyncActions({ types: GET_PICTURES, namespace: 'picture' });

export const pictureMutations = createMutations({ names: ['saveAll', 'save', 'delete'], namespace: 'picture' });
