import { CREATE_PICTURE, createPictureActions } from './actions';
import { createApiRequest } from '../../../../common/store/apiRequest';
import { notifyActions } from '../../../../common/store/notifications';
import router from '../../../../router';

const actions = {
  [CREATE_PICTURE.REJECTED]: () => {
    console.log('========== err =========');
  },
  [CREATE_PICTURE.FULFILLED]: () => {
    router.push('/pictures');
  },
  [CREATE_PICTURE.DEFAULT]: (context, { file, ...rest }) => {
    const { fulfill } = createPictureActions(context);
    const { error, success } = notifyActions(context);

    createApiRequest(context)({
      data: { ...rest, content: file },
      api: 'formDataApi',
      url: 'images/create',
      method: 'post',
      onSuccess: [fulfill, () => success({ message: 'Successfully created a picture!' })],
      onFailure: [error],
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
