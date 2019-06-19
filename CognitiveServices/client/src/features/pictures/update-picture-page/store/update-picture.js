import { UPDATE_PICTURE, updatePictureActions } from './actions';
import { createApiRequest } from '../../../../common/store/apiRequest';
import { notifyActions } from '../../../../common/store/notifications';
import router from '../../../../router';

const actions = {
  [UPDATE_PICTURE.REJECTED]: (context, payload) => {
    console.log(payload);
  },
  [UPDATE_PICTURE.FULFILLED]: () => {
    router.push('/');
  },
  [UPDATE_PICTURE.DEFAULT]: (context, {
    file, id, content, ...rest
  }) => {
    const { fulfill, reject } = updatePictureActions(context);
    const { error } = notifyActions(context);

    createApiRequest(context)({
      data: { ...rest, content: file || content },
      api: 'formDataApi',
      url: `images/update/${id}`,
      method: 'put',
      onSuccess: [fulfill],
      onFailure: [reject, error],
    });
  },
};

export default {
  namespaced: true,
  actions,
};
