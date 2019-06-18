import { createAsyncActionType, createAsyncActions } from '../../../../common/utilities';

export const UPDATE_PICTURE = createAsyncActionType('UPDATE_PICTURE');

export const updatePictureActions = createAsyncActions({ types: UPDATE_PICTURE, namespace: 'updatePicture' });
