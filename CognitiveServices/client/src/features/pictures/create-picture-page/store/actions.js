import { createAsyncActionType, createAsyncActions } from '../../../../common/utilities';

export const CREATE_PICTURE = createAsyncActionType('CREATE_PICTURE');

export const createPictureActions = createAsyncActions({ types: CREATE_PICTURE, namespace: 'createPicture' });
