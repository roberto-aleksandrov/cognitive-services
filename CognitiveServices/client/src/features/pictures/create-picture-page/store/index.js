import { CREATE_PICTURE, createPictureActions } from './actions';
import { createApiRequest } from '../../../../common/store/apiRequest';

const actions = {
  [CREATE_PICTURE.REJECTED]: () => {
    console.log('========== err =========');
  },

  [CREATE_PICTURE.DEFAULT]: (context, { file, ...rest }) => {
    createApiRequest(context)({
      data: { ...rest, content: file },
      api: 'formDataApi',
      url: 'images/create',
      method: 'post',
      actions: createPictureActions,
    });
  },
};

const mutations = {
  savePicture(state, payload) {
    state.pictures = payload;
  },
};

const state = {

};

export default {
  namespaced: true,
  state,
  mutations,
  actions,
};
