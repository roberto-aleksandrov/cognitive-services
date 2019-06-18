import {
  GET_PICTURES,
  GET_PICTURE,
  DELETE_PICTURE,
  getPicturesActions,
  pictureMutations,
  deletePictureActions,
} from './actions';
import { createApiRequest } from '../apiRequest';
import { notifyActions } from '../notifications';

const actions = {
  [GET_PICTURES.DEFAULT]: (context) => {
    const { saveAll } = pictureMutations(context);

    createApiRequest(context)({
      api: 'ajaxApi',
      url: 'images/getall',
      method: 'get',
      onSuccess: [saveAll],
    });
  },
  [GET_PICTURE.DEFAULT]: (context, payload) => {
    const { reject } = getPicturesActions(context);
    const { save } = pictureMutations(context);

    createApiRequest(context)({
      api: 'ajaxApi',
      url: `images/get/${payload.id}`,
      method: 'get',
      onSuccess: [save],
      onFailure: [reject],
    });
  },
  [DELETE_PICTURE.DEFAULT]: (context, payload) => {
    const { reject } = deletePictureActions(context);
    const { delete: deleteItem } = pictureMutations(context);
    const { success, error } = notifyActions(context);

    createApiRequest(context)({
      api: 'ajaxApi',
      url: `images/delete/${payload.id}`,
      method: 'delete',
      onSuccess: [deleteItem, () => success({ message: 'Successfully deleted a picture' })],
      onFailure: [reject, error],
    });
  },
};

const mutations = {
  saveAll: (state, payload) => {
    state.pictures = payload.data;
  },
  save: (state, payload) => {
    state.picture = payload.data;
  },
  delete: (state, payload) => {
    state.pictures = state.pictures.filter(n => payload.data.id !== n.id);
  },
};

const state = {
  pictures: [],
  picture: {},
};

export default {
  namespaced: true,
  actions,
  mutations,
  state,
};
